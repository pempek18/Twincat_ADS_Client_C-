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
                return "";
            }
            
        }

        public IValueSymbol GetAdsVariable(string name)
        {
            try
            {
                var symbolLoader = TwinCAT.Ads.TypeSystem.SymbolLoaderFactory.Create(ads, TwinCAT.SymbolLoaderSettings.Default);
                IValueSymbol Symbol = (IValueSymbol)symbolLoader.Symbols[name];
                return Symbol;
            }catch(Exception e)
            {
                timer1.Enabled = false;
                MessageBox.Show("Symbol not found:\n" + name);
                this.Close();
                return null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var symbolLoader = TwinCAT.Ads.TypeSystem.SymbolLoaderFactory.Create(ads, TwinCAT.SymbolLoaderSettings.Default);
            IArrayInstance Symbol = (IArrayInstance)symbolLoader.Symbols[".stTrgsParams"];
            bool test = false;
            // stTrgsParams[0].iTriggerDly = GetAdsVariable(".stTrgsParams[0].iTriggerDly");
            //userControl11.Textbox_1 = stTrgsParams[0].iTriggerDly.ReadValue().ToString();
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
