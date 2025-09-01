using System;
using System.Collections.Generic;

namespace Guan
{
	internal class ClassLanguage
	{
		public static event ClassLanguage.LanguageIsChanged LanguageEvent;

		public static void SetLanguage(ClassLanguage.LanguageType lType)
		{
			if (ClassLanguage.m_isFirstSet || ClassLanguage.m_language != lType)
			{
				ClassLanguage.m_isFirstSet = false;
				ClassLanguage.m_language = lType;
				if (ClassLanguage.LanguageEvent != null)
				{
					ClassLanguage.LanguageEvent();
				}
			}
		}

		public static void InitDictionary()
		{
			ClassLanguage.m_dictionary.Add("Config_Title", new string[] { "光立方数据生成软件", "", "" });
			ClassLanguage.m_dictionary.Add("Config_Type1", new string[] { "(演示版)", "", "" });
			ClassLanguage.m_dictionary.Add("Config_Type2", new string[] { "(正式版)", "", "" });
			ClassLanguage.m_dictionary.Add("Config_Type3", new string[] { "(定制版)", "", "" });
			ClassLanguage.m_dictionary.Add("Menu_File", new string[] { "文件", "文件", "File" });
			ClassLanguage.m_dictionary.Add("Menu_Debug", new string[] { "调试", "調試", "" });
			ClassLanguage.m_dictionary.Add("Menu_Config", new string[] { "配置", "配置", "" });
			ClassLanguage.m_dictionary.Add("Menu_Lauguage", new string[] { "简体中文", "繁體中文", "" });
			ClassLanguage.m_dictionary.Add("Menu_Help", new string[] { "帮助", "幫助", "" });
			ClassLanguage.m_dictionary.Add("Menu_New", new string[] { "新建", "新建", "" });
			ClassLanguage.m_dictionary.Add("Menu_Open", new string[] { "打开", "打開", "" });
			ClassLanguage.m_dictionary.Add("Menu_Save", new string[] { "保存", "保存", "" });
			ClassLanguage.m_dictionary.Add("Menu_SaveAs", new string[] { "另存为", "另存為", "" });
			ClassLanguage.m_dictionary.Add("Menu_Compile", new string[] { "编译生成烧写文件", "編譯生成燒寫文件", "" });
			ClassLanguage.m_dictionary.Add("Menu_DebugRun", new string[] { "电脑仿真运行", "電腦仿真運行", "" });
			ClassLanguage.m_dictionary.Add("Menu_ConfigDebug", new string[] { "调试配置", "調試配置", "" });
			ClassLanguage.m_dictionary.Add("Menu_HelpUse", new string[] { "使用说明", "使用說明", "" });
			ClassLanguage.m_dictionary.Add("Menu_AboutUs", new string[] { "关于我们", "關於我們", "" });
			ClassLanguage.m_dictionary.Add("Menu_Exit", new string[] { "退出", "退出", "" });
			ClassLanguage.m_dictionary.Add("Group_CartoonGroup", new string[] { "动画组", "", "" });
			ClassLanguage.m_dictionary.Add("Group_Preview", new string[] { "预览效果", "", "" });
			ClassLanguage.m_dictionary.Add("Group_GraRes", new string[] { "图形资源", "", "" });
			ClassLanguage.m_dictionary.Add("Group_ResIndex", new string[] { "资源索引表", "", "" });
			ClassLanguage.m_dictionary.Add("File_Filter", new string[] { "光立方工程文件", "", "" });
			ClassLanguage.m_dictionary.Add("File_Other1", new string[] { "工程已经修改，是否需要先保存再关闭?", "", "" });
			ClassLanguage.m_dictionary.Add("File_Other2", new string[] { "提示", "", "" });
			ClassLanguage.m_dictionary.Add("File_Other3", new string[] { "文件保存失败!", "", "" });
			ClassLanguage.m_dictionary.Add("File_Other4", new string[] { "工程已经修改，是否需要先保存再退出?", "", "" });
			ClassLanguage.m_dictionary.Add("File_Other5", new string[] { "文件打开失败!", "", "" });
			ClassLanguage.m_dictionary.Add("File_Other6", new string[] { "成功", "", "" });
			ClassLanguage.m_dictionary.Add("File_Other7", new string[] { "错误", "", "" });
			ClassLanguage.m_dictionary.Add("IndexTree_SingleIndex", new string[] { "平面图形索引", "", "" });
			ClassLanguage.m_dictionary.Add("IndexTree_SolidIndex", new string[] { "立体图形索引", "", "" });
			ClassLanguage.m_dictionary.Add("IndexTree_NumberIndex", new string[] { "数值索引", "", "" });
			ClassLanguage.m_dictionary.Add("IndexTree_ResOut", new string[] { "资源数超上限，无法继续添加!", "", "" });
			ClassLanguage.m_dictionary.Add("IndexTree_Table", new string[] { "表格", "", "" });
			ClassLanguage.m_dictionary.Add("IndexTree_RenameFail", new string[] { "重命名失败,该名称已经存在!", "", "" });
			ClassLanguage.m_dictionary.Add("ResTree_Single", new string[] { "平面图形", "", "" });
			ClassLanguage.m_dictionary.Add("ResTree_Solid", new string[] { "立体图形", "", "" });
			ClassLanguage.m_dictionary.Add("ResTree_ResOut", new string[] { "资源数超上限，无法继续添加!", "", "" });
			ClassLanguage.m_dictionary.Add("ResTree_RenameFail", new string[] { "重命名失败,该名称已经存在!", "", "" });
			ClassLanguage.m_dictionary.Add("ResTree_Table", new string[] { "图形", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_AddIndex", new string[] { "添加索引表", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_Add", new string[] { "添加", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_Rename", new string[] { "重命名", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_Delete", new string[] { "删除", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_Copy", new string[] { "复制(CTRL+C)", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_Paste", new string[] { "粘贴(CTRL+V)", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_AddDot", new string[] { "添加点操作", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_AddLine", new string[] { "添加线操作", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_AddPannel", new string[] { "添加平面操作", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_AddSolid", new string[] { "添加立体操作", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_AddBright", new string[] { "添加亮度操作", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_Up", new string[] { "上移", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_Down", new string[] { "下移", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_AddFrame", new string[] { "添加帧", "", "" });
			ClassLanguage.m_dictionary.Add("MeunStrip_DeleteFrame", new string[] { "删除帧", "", "" });
			ClassLanguage.m_dictionary.Add("Edit_CloseAll", new string[] { "关闭全部", "", "" });
			ClassLanguage.m_dictionary.Add("Edit_ViewFont", new string[] { "正面视图: 第{0}层", "", "" });
			ClassLanguage.m_dictionary.Add("Edit_ViewLeft", new string[] { "左面视图: 第{0}层", "", "" });
			ClassLanguage.m_dictionary.Add("Edit_ViewTop", new string[] { "顶面视图: 第{0}层", "", "" });
			ClassLanguage.m_dictionary.Add("Edit_LoopCount", new string[] { "循环次数", "", "" });
			ClassLanguage.m_dictionary.Add("Edit_FrameCount", new string[] { "帧数", "", "" });
			ClassLanguage.m_dictionary.Add("Edit_FrameInterval", new string[] { "帧间隔", "", "" });
			ClassLanguage.m_dictionary.Add("Edit_FrameClean", new string[] { "换帧时清除显示缓存", "", "" });
			ClassLanguage.m_dictionary.Add("Shaft_Function", new string[] { "操 作", "", "" });
			ClassLanguage.m_dictionary.Add("Shaft_F_Dot", new string[] { "点操作", "", "" });
			ClassLanguage.m_dictionary.Add("Shaft_F_Line", new string[] { "线操作", "", "" });
			ClassLanguage.m_dictionary.Add("Shaft_F_Pannel", new string[] { "平面操作", "", "" });
			ClassLanguage.m_dictionary.Add("Shaft_F_Solid", new string[] { "立体操作", "", "" });
			ClassLanguage.m_dictionary.Add("Shaft_F_Bright", new string[] { "亮度操作", "", "" });
		}

		public static string GetString(string name)
		{
			string[] array;
			if (ClassLanguage.m_dictionary.TryGetValue(name, out array))
			{
				return array[(int)ClassLanguage.m_language];
			}
			return "";
		}

		private const int maxLanguage = 3;

		private static ClassLanguage.LanguageType m_language = ClassLanguage.LanguageType.Simplified;

		private static bool m_isFirstSet = true;

		private static Dictionary<string, string[]> m_dictionary = new Dictionary<string, string[]>();

		public enum LanguageType
		{
			Simplified,
			Traditional,
			English
		}

		public delegate void LanguageIsChanged();
	}
}
