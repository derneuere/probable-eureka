#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class TextEntryPopup : PopupWindowContent
{        
	public delegate void StringCallback(string message);

        
	private string _data;        
	private readonly StringCallback _callback;
	private readonly Rect _dims;

	private TextEntryPopup(string data, StringCallback callback, Rect dims)
	{
		_data = data;
		_callback = callback;
		_dims = dims;
	}

	public static void Open(string data, StringCallback callback, Rect dims)
	{
		PopupWindow.Show(dims, new TextEntryPopup(data, callback, dims));				
	}
        
	public override Vector2 GetWindowSize()
	{
		return new Vector2(_dims.width, 20);
	}

	public override void OnGUI(Rect rect)
	{
		GUIStyle style = new GUIStyle(GUI.skin.textField) {alignment = TextAnchor.MiddleCenter};
		GUI.SetNextControlName("textfield");
		_data = EditorGUILayout.DelayedTextField(_data, style, GUILayout.ExpandWidth(true));
		GUI.FocusControl("textfield");
	}	

	public override void OnClose()
	{
		_callback(_data);
	}
}

public static class Shapes
{
	private static readonly GUIStyle TextureStyle = new GUIStyle(GUI.skin.button) {wordWrap = false};
 
	public static void DrawRect(Vector2 position, Color color, GUIContent content = null)
	{
		var background_color = GUI.backgroundColor;
		GUI.backgroundColor = color;
		var size = TextureStyle.CalcSize(content);
		GUI.Box(new Rect(position - size/2.0f, size), content ?? GUIContent.none, TextureStyle);
		GUI.backgroundColor = background_color;
	}
 
	public static void LayoutBox(Color color, GUIContent content = null)
	{
		var background_color = GUI.backgroundColor;
		GUI.backgroundColor = color;
		GUILayout.Box(content ?? GUIContent.none, TextureStyle);
		GUI.backgroundColor = background_color;
	}
}
 
 
public static class WindowIdManager
{
	private static int _nextId = 10000; 

	public static int unique
	{
		get { return _nextId++; }
	}
}
#endif

/*
Written by Moritz Voss in 2018

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org>
*/