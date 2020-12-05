using PEPExtensions;
using PEPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeBisecter
{
    public class EdgeBisecter : IPEPlugin
    {
        private bool disposedValue;

        public string Name => "辺を分割";

        public string Version => "1.0";

        public string Description => "選択した2頂点間の辺を分割する";

        public IPEPluginOption Option => new PEPluginOption(false, true);

        private FormControl form;

        public void Run(IPERunArgs args)
        {
            try
            {
                if (form == null)
                {
                    form = new FormControl(args);
                    form.Visible = true;
                    form.Reload();
                }
                else
                {
                    form.Visible = !form.Visible;
                    if (form.Visible)
                        form.Reload();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowException(ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~Class1()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
