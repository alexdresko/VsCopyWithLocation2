using System.Globalization;
using EnvDTE;


namespace CUSTIS.CopyWithLocation
{
    public static class TextSelectionExtensions {

        public static string GetClassName(this TextSelection ts)
        {
            if (ts != null)
            {
                var topClassName = GetClassName(ts.TopPoint);
                var bottomClassName = GetClassName(ts.BottomPoint);
                return topClassName == bottomClassName ? topClassName : string.Empty;
            }
            return string.Empty;
        }

        private static string GetClassName(VirtualPoint virtualPoint)
        {
            if (virtualPoint != null)
            {
                var codeClass = virtualPoint.CodeElement[vsCMElement.vsCMElementClass] as CodeClass;
                if (codeClass != null)
                {
                    return codeClass.Name;
                }

                var codeInterface = virtualPoint.CodeElement[vsCMElement.vsCMElementInterface] as CodeInterface;
                if (codeInterface != null)
                {
                    return codeInterface.Name;
                }

                var codeStruct = virtualPoint.CodeElement[vsCMElement.vsCMElementStruct] as CodeStruct;
                if (codeStruct != null)
                {
                    return codeStruct.Name;
                }

                var codeEnum = virtualPoint.CodeElement[vsCMElement.vsCMElementEnum] as CodeEnum;
                if (codeEnum != null)
                {
                    return codeEnum.Name;
                }
            }
            return string.Empty;
        }

        public static string GetMethodName(this TextSelection ts)
        {
            if (ts != null)
            {
                var topMethodName = GetMethodName(ts.TopPoint);
                var bottomMethodName = GetMethodName(ts.BottomPoint);
                return topMethodName == bottomMethodName ? topMethodName : string.Empty;
            }

            return string.Empty;
        }

        private static string GetMethodName(VirtualPoint virtualPoint)
        {
            if (virtualPoint != null)
            {
                var codeMethod = virtualPoint.CodeElement[vsCMElement.vsCMElementFunction] as CodeFunction;
                if (codeMethod != null)
                {
                    return codeMethod.Name;
                }

                var codeProperty = virtualPoint.CodeElement[vsCMElement.vsCMElementProperty] as CodeProperty;
                if (codeProperty != null)
                {
                    return codeProperty.Name;
                }
            }
            return string.Empty;
        }

        public static string GetSelectedLines(this TextSelection textSelection)
        {
            var lineBeg = textSelection.TopPoint.Line;
            var lineEnd = textSelection.BottomPoint.Line;
            var selectedLines = lineBeg == lineEnd ? lineBeg.ToString() : string.Format("{0}-{1}", lineBeg, lineEnd);
            return selectedLines;
        }

    }
}