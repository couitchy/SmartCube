using System;

namespace Guan
{
    internal class Config
    {
        public static string Title
        {
            get
            {
                return "3D*8 Leds soft(customization)";
            }
        }

        public static uint outputStartVale
        {
            get
            {
                return 256U;
            }
        }

        public static uint outputLenLimit
        {
            get
            {
                return Config.outputLenMax;
            }
        }

        public static uint outputLenMax
        {
            get
            {
                return 25856U;
            }
        }

        public static bool enableOutput
        {
            get
            {
                return true;
            }
        }

        public static bool DZ_Rotate
        {
            get
            {
                return true;
            }
        }

        public static bool EnableEnhanced
        {
            get
            {
                return true;
            }
        }

        public static string FileSuffix
        {
            get
            {
                return "gpro8";
            }
        }

        public static string DZElementCopyString
        {
            get
            {
                return "DzElement8";
            }
        }

        public static string ControlCopyString
        {
            get
            {
                return "CartoonControl8";
            }
        }

        public static string GroupCopyString
        {
            get
            {
                return "CartoonGroup8";
            }
        }

        public static string SingleCopyString
        {
            get
            {
                return "SingleGraph8";
            }
        }

        public static string SolidCopyString
        {
            get
            {
                return "SolidGraph8";
            }
        }

        public static string SingleIndexCopyString
        {
            get
            {
                return "SingleIndex8";
            }
        }

        public static string SolidIndexCopyString
        {
            get
            {
                return "SolidIndex8";
            }
        }

        public static string NumberIndexCopyString
        {
            get
            {
                return "NumberIndex8";
            }
        }

        public static int MaxGraph
        {
            get
            {
                return 255;
            }
        }

        public static int MaxIndexTable
        {
            get
            {
                return 127;
            }
        }

        public static int MaxIndexElement
        {
            get
            {
                return 255;
            }
        }

        public static string CartoonGroup
        {
            get
            {
                return "Cartoon Group";
            }
        }

        public static string CartoonElement
        {
            get
            {
                return "Cartoon Element";
            }
        }

        public static string OperationDot
        {
            get
            {
                return "Dot Operation";
            }
        }

        public static string OperationLine
        {
            get
            {
                return "Line Operation";
            }
        }

        public static string OperationPannel
        {
            get
            {
                return "Pannel Operation";
            }
        }

        public static string OperationSolid
        {
            get
            {
                return "Solid Operation";
            }
        }

        public static string OperationBright
        {
            get
            {
                return "Bright Operation";
            }
        }

        public static string IndexPannel
        {
            get
            {
                return "Pannel Index";
            }
        }

        public static string IndexSolid
        {
            get
            {
                return "Solid Index";
            }
        }

        public static string IndexValue
        {
            get
            {
                return "Value Index";
            }
        }

        public static string SourceOut
        {
            get
            {
                return "Resources for the ultra limit, can't continue to add!";
            }
        }

        public static string RenameFailed
        {
            get
            {
                return "Rename fails, this name already exists!";
            }
        }

        public static string GraphPannel
        {
            get
            {
                return "Pannel Graph";
            }
        }

        public static string GraphSolid
        {
            get
            {
                return "Solid Graph";
            }
        }

        private const Config.EnumSoft SoftFlag = Config.EnumSoft.enhanced;

        public const uint outputLen = 25856U;

        private const uint outputStart = 256U;

        private enum EnumSoft
        {
            test,
            normal,
            enhanced
        }
    }
}
