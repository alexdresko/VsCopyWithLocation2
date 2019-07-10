using System.Windows.Forms;
using Custis.CopyWithLocation;
using EnvDTE;
using EnvDTE80;


namespace CUSTIS.CopyWithLocation
{
    public sealed class ExtendedCopier
    {
        public static void CopySelectionWithLocation(DTE dte, CopyWithLocationOptions options)
        {
            var activeDocument = dte.ActiveDocument;
            if (activeDocument == null)
            {
                return;
            }

            var textSelection = activeDocument.Selection as TextSelection;
            if (textSelection == null)
            {
                return;
            }

            var methodName = textSelection.GetMethodName();
            var className = textSelection.GetClassName();
            var selectedLines = textSelection.GetSelectedLines();

            var format =
                string.IsNullOrEmpty(className)
                    ? options.CodeBlockCopyFormat
                    : string.IsNullOrEmpty(methodName)
                          ? options.ClassCopyFormat
                          : options.MethodCopyFormat;

            if (string.IsNullOrEmpty(className))
            {
                className = activeDocument.Path;
                methodName = activeDocument.Name;
            }

            var selectionWithLocation = string.Format(format, className, methodName, selectedLines, textSelection.Text);

            Clipboard.SetText(selectionWithLocation);
        }

    }
}