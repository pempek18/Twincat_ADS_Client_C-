using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using TwinCAT.Ads;
using TwinCAT.Ads.TcpRouter;
using Microsoft.AspNetCore.Components;
using System.Xml;

namespace Twincat_Visu_Ads
{
    public partial class AdsRouter : Form, ILogger
    {
        private AmsTcpIpRouter _router;
        private CancellationTokenSource _cancel;
        private SynchronizationContext _ctx;

        AmsNetId _local = new AmsNetId("192.168.58.1.1.1");
        static AmsNetId _remoteNetId = new AmsNetId("169.254.13.29.1.1");
        static IPAddress _remoteIp = IPAddress.Parse("192.168.58.128");
        static string _remoteRouteName = "VM";
        private AdsClient ads = new AdsClient();
        public AdsRouter()
        {
            InitializeComponent();

            _ctx = SynchronizationContext.Current;

            //AmsNetId netId = new AmsNetId("1.2.3.4.5.6");
            //Debug.Fail("");
            //_cancel = new CancellationTokenSource();
            enableDisableControls();
        }

        private void AdsRouter_OnLoad()
        {
            XmlDocument document = new XmlDocument();
            //document.LoadXml(StaticRoutes.xml);
            //comboBox1.Items.AddRange( StaticRoutes.xml);
        }

        private void _router_RouterStatusChanged(object sender, RouterStatusChangedEventArgs e)
        {
            _ctx.Post((state) =>
            {
                if (_router != null)
                    lblStatus.Text = _router.RouterStatus.ToString();
                else
                    lblStatus.Text = "";
                enableDisableControls();
            }
            , null);
        }

        private void AdsConnection()
        {
        }

        private void enableDisableControls()
        {
            bool validNetId = AmsNetId.TryParse(tbNetId.Text, out _local);
            btnStart.Enabled = validNetId;
            btnStop.Enabled = false;
            btnCancel.Enabled = _cancel != null;
            tbNetId.Enabled = true;

            if (_router != null)
            {
                switch (_router.RouterStatus)
                {
                    case RouterStatus.Initializing:
                    case RouterStatus.Stopping:
                        btnStart.Enabled = false;
                        btnStop.Enabled = false;
                        tbNetId.Enabled = false;
                        break;

                    case RouterStatus.Stopped:
                        btnStart.Enabled = validNetId;
                        btnStop.Enabled = false;
                        tbNetId.Enabled = true;
                        break;
                    case RouterStatus.Started:
                        btnStart.Enabled = false;
                        btnStop.Enabled = true;
                        tbNetId.Enabled = false;
                        break;

                    case RouterStatus.Starting:
                        btnStart.Enabled = false;
                        btnStop.Enabled = false;
                        tbNetId.Enabled = false;
                        break;

                    default:
                        throw new NotSupportedException();
                }
            }
        }
        public string GetAdsVariableValueString<T>(string name)
        {
            return ((T)ads.ReadAny(ads.CreateVariableHandle(name), typeof(T))).ToString();
        }


        private async void btnStart_Click(object sender, EventArgs e)
        {
            _router = new AmsTcpIpRouter(_local);
            _router.AddRoute(new Route(_remoteRouteName, _remoteNetId, new IPAddress[] { _remoteIp }));
            
            _router.RouterStatusChanged += _router_RouterStatusChanged;
            lblStatus.Text = _router.RouterStatus.ToString();

            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            _cancel = new CancellationTokenSource();

            //try
            //{
            //    ads.Connect(_remoteNetId, 851);
            //    string test = GetAdsVariableValueString<Int16>(".NofStns");
            //    AppendLoggerList("NofStns : " + test);
            //    //await _router.StartAsync(_cancel.Token);
            //}
            //catch (Exception err1)
            //{
            //    AppendLoggerList("_router.StartAsync:" + err1);
            //}

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _router.Stop();
            _router.RouterStatusChanged -= _router_RouterStatusChanged;
            _router = null;
            _cancel = null;
            enableDisableControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_cancel != null)
                _cancel.Cancel();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!((ILogger)(this)).IsEnabled(logLevel))
                return;

            string message = formatter(state, exception);
            AppendLoggerList(message);
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public void AppendLoggerList(string logMessage)
        {
            lbLog.Items.Add(logMessage);
        }

        private void tbNetId_TextChanged(object sender, EventArgs e)
        {
            enableDisableControls();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lbLog.Items.Clear();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        private void btnStartAds_Click(object sender, EventArgs e)
        {
           // using var ads = new AdsClient(loggerFactory.CreateLogger("AdsClient"));
        }
    }
}
