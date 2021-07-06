using System;
using System.IO;
using System.Management.Automation;
using AssetStudio;

namespace AssetStudioModule
{
    [Cmdlet(VerbsData.Import, "UnityAsset")]
    public class LoadFiles : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
        public string[] Files { get; set; } = Array.Empty<string>();

        protected override void BeginProcessing()
        {
            Directory.SetCurrentDirectory(this.SessionState.Path.CurrentFileSystemLocation.Path);
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            for (var i = 0; i < Files.Length; i++) 
                Files[i] = Path.GetFullPath(Files[i]);

            var assetManager = new AssetsManager();
            assetManager.LoadFiles(Files);
            WriteObject(assetManager);
            base.ProcessRecord();
        }
    }

    [Cmdlet(VerbsCommon.Get, "Texture2D")]
    public class ReadTexture2D : PSCmdlet
    {
        
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
        public Texture2D File { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(File.ConvertToImage(true));
        }
    }
}
