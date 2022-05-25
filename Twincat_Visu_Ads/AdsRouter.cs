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

namespace Twincat_Visu_Ads
{
    public partial class AdsRouter : Form, ILogger
    {
        private AmsTcpIpRouter _router;
        private CancellationTokenSource _cancel;
        private SynchronizationContext _ctx;

        AmsNetId _local = new AmsNetId("1.2.3.4.5.6");
        public AdsRouter()
        {
            InitializeComponent();

            _ctx = SynchronizationContext.Current;

            //AmsNetId netId = new AmsNetId("1.2.3.4.5.6");
            //Debug.Fail("");
            //_cancel = new CancellationTokenSource();
            enableDisableControls();
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

        private async void btnStart_Click(object sender, EventArgs e)
        {
            _router = new AmsTcpIpRouter(_local, AmsTcpIpRouter.DEFAULT_TCP_PORT, null, AmsTcpIpRouter.DEFAULT_TCP_PORT, (IPNetwork)null, this);
            _router.RouterStatusChanged += _router_RouterStatusChanged;
            lblStatus.Text = _router.RouterStatus.ToString();

            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            _cancel = new CancellationTokenSource();
            try
            {
               await _router.StartAsync(_cancel.Token);
            }catch
            {
                tbNetId.Text = "Connection failed";
            }

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
    }
}
