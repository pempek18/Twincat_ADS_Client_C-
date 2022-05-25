using System;
using System.Drawing;
using System.Windows.Forms;
using TwinCAT.Ads;
using TwinCAT.TypeSystem;

namespace Beckhoff_VS_Visualisation
{
    public partial class TriggersReject : Form
    {
        public TriggersReject()
        {
            InitializeComponent();
            CheckConnectionWithLocalPLC();
        }
        private AdsClient ads = new AdsClient();
        int errorCnt=0;
        private struct ST_Trigger_Params
        {
            public IValueSymbol iTriggerDly, iBlowerPos, iBlowLenght;
            public IValueSymbol bDisableBlower;
        }
        ST_Trigger_Params[] stTrgsParams = new ST_Trigger_Params[4];
        public void TriggersReject_OnLoad(object sender, EventArgs e)
        {
            
        }

        public string GetAdsVariableValueString<T>(string name)
        {
            try
            {
                return ((T)ads.ReadAny(ads.CreateVariableHandle(name), typeof(T))).ToString();
            }catch(Exception e)
            {
                errorCnt++;
                return "";
            }
            
        }

        public IValueSymbol GetAdsVariable(string name)
        {
            try
            {
                ISymbolLoader symbolLoader = TwinCAT.Ads.TypeSystem.SymbolLoaderFactory.Create(ads, TwinCAT.SymbolLoaderSettings.Default);
                IValueSymbol Symbol = (IValueSymbol)symbolLoader.Symbols[name];
                return Symbol;
            }catch(Exception e)
            {
                errorCnt++;
                return null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                using (ads)
                {
                     ISymbolLoader symbolLoader = TwinCAT.Ads.TypeSystem.SymbolLoaderFactory.Create(ads, TwinCAT.SymbolLoaderSettings.Default);
                    IArrayInstance Symbol = (IArrayInstance)symbolLoader.Symbols[".stTrgsParams"];
                    // stTrgsParams[0].iTriggerDly = GetAdsVariable(".stTrgsParams[0].iTriggerDly");
                    //userControl11.Textbox_1 = stTrgsParams[0].iTriggerDly.ReadValue().ToString();
                }
            }
            catch
            {
                errorCnt++;
            }

        }

        public bool CheckConnectionWithLocalPLC()
        {
            try
            {
                ads.Connect(AmsNetId.Local, 851);
                return (ads.IsConnected);
            }
            catch (Exception error)
            {
                timer1.Enabled = false;
                return (ads.IsConnected);
                MessageBox.Show(error.Message.ToString());
            }
        }
    }
}
