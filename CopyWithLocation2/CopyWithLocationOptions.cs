using System.ComponentModel;
using Microsoft.VisualStudio.Shell;


namespace Custis.CopyWithLocation
{
    public class CopyWithLocationOptions : DialogPage
    {
        [DisplayName("Method copy format")]
        [Description("Use \"{0}.{1}:{2}: {3}\" to copy method like \"MyClass.MyMethod:LineBeg-LineEnd: Selected code\"")]
        public string MethodCopyFormat { get; set; }

        [DisplayName("Class copy format")]
        [Description("Use \"{0}:{2}: {3}\" to copy class like \"MyClass:LineBeg-LineEnd: Selected code\"")]
        public string ClassCopyFormat { get; set; }

        [DisplayName("Code block copy format")]
        [Description("Use \"{0}{1}:{2}: {3}\" to copy code block like \"FilePath\\FileName:LineBeg-LineEnd: Selected code\"")]
        public string CodeBlockCopyFormat { get; set; }

        public override void ResetSettings()
        {
            MethodCopyFormat = null;
            ClassCopyFormat = null;
            CodeBlockCopyFormat = null;

            base.ResetSettings();
        }

        protected override void OnActivate(CancelEventArgs e)
        {
            LoadDefaultSettingsIfNecessary();

            base.OnActivate(e);
        }

        public void LoadDefaultSettingsIfNecessary()
        {
            MethodCopyFormat = string.IsNullOrEmpty(MethodCopyFormat) ? "{0}.{1}:{2}: {3}" : MethodCopyFormat;
            ClassCopyFormat = string.IsNullOrEmpty(ClassCopyFormat) ? "{0}:{2}: {3}" : ClassCopyFormat;
            CodeBlockCopyFormat = string.IsNullOrEmpty(CodeBlockCopyFormat) ? "{1}:{2}: {3}" : CodeBlockCopyFormat;
        }
    }
}