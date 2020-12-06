using System;
using System.IO;
using System.Management.Automation;
using AssetStudio;

namespace AssetStudioModule
{
    [Cmdlet(VerbsData.Import, "UnityAsset")]
    public class LoadFiles : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string[] Files { get; set; } = Array.Empty<string>();

        protected override void ProcessRecord()
        {
            Directory.SetCurrentDirectory(this.SessionState.Path.CurrentFileSystemLocation.Path);

            var assetManager = new AssetStudio.AssetsManager();
            assetManager.LoadFiles(Files);
            WriteObject(assetManager);
            base.ProcessRecord();
        }
    }

    [Cmdlet(VerbsCommon.Get, "Texture2D")]
    public class ReadTexture2D : PSCmdlet
    {
        
        [Parameter(Position = 0, Mandatory = true)]
        public Texture2D File { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(File.ConvertToBitmap(true));
        }
    }
}
