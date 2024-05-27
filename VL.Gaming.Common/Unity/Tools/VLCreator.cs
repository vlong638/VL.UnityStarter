using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Common;
using VL.Gaming.Unity.Gaming.Ultis;

namespace VL.Gaming.Unity.Tools
{
    public enum SortingOrder
    {
        None = 0,
        Floor = 3,
        Item = 5,
        Creature = 9,
        AboveAll = 10,
    }
    public static class VLSample
    {
        public static void Edit_Camera()
        {
            Camera.main.fieldOfView = 60;//设置相机视野为60度
            Camera.main.clearFlags = CameraClearFlags.SolidColor;//设置相机清除标志为纯色
            Camera.main.backgroundColor = Color.blue;//设置相机背景色为蓝色
            Camera.main.orthographic = true;//设置相机为正交投影模式
            Camera.main.orthographicSize = 5;//设置正交相机的大小为5
            Camera.main.nearClipPlane = 0.3f;//设置相机近裁剪面为0.3
            Camera.main.farClipPlane = 1000f;//设置相机远裁剪面为1000
            Camera.main.depth = 1;//设置相机的深度为1，影响渲染顺序
            Camera.main.allowHDR = true;//允许相机使用HDR颜色
            Camera.main.allowMSAA = true;//允许相机使用抗锯齿
            Camera.main.useOcclusionCulling = true;//开启遮挡剔除
            Camera.main.cullingMask = 1 << LayerMask.NameToLayer("Default");//设置相机剔除哪些层的物体
            Camera.main.backgroundColor = Color.clear;//设置相机背景色为透明

            //camera.fieldOfView = 60f;//设置相机视野为60度
            //camera.backgroundColor = Color.blue;//设置相机背景色为蓝色
            //camera.orthographic = true;//设置为正交投影模式
            //camera.orthographicSize = 5f;//设置正交投影的视口大小
            //camera.nearClipPlane = 0.3f;//设置相机近裁剪面距离
            //camera.farClipPlane = 1000f;//设置相机远裁剪面距离
            //camera.clearFlags = CameraClearFlags.SolidColor;//设置相机清除标志为颜色
            //camera.cullingMask = 1 << LayerMask.NameToLayer("Default");//设置相机的剔除掩码
            //camera.transform.position = new Vector3(0, 10, -10);//设置相机位置
            //camera.transform.rotation = Quaternion.Euler(30, 0, 0);//设置相机欧拉角
            //camera.transform.localScale = new Vector3(1, 1, 1);//设置相机缩放
            //var otherGO = new GameObject("test");
            //camera.transform.SetParent(otherGO.transform);//将相机设置为某个游戏物体的子物体
            //camera.transform.localPosition = new Vector3(0, 0, 5);//设置相机在其父物体空间中的位置
        }
        public static void Edit_Canvas()
        {
            GameObject gameObject = new GameObject("name");
            GameObject parent = new GameObject("parent");
            if (parent) gameObject.transform.SetParent(parent.transform);
            var canvas = gameObject.AddComponent<Canvas>();
            var canvasScaler = gameObject.AddComponent<CanvasScaler>();
            var graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;// 设置Canvas的渲染模式为屏幕空间覆盖
            canvas.pixelPerfect = true;// 启用或禁用像素完美模式
            canvas.sortingOrder = 1;// 设置Canvas的排序层级
            canvas.planeDistance = 10f;// 设置Canvas的平面距离
            canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1;// 启用或禁用额外的背景顶点填充（[Pro Only]）
            canvas.scaleFactor = 1.5f;// 设置Canvas的缩放模式
            //canvas.dynamicPixelsPerUnit = true;// 启用或禁用Canvas根据屏幕缩放进行缩放
            canvas.worldCamera = Camera.main;// 设置Canvas的渲染相机
            //canvas.normalizeMousePosition = true;// 启用或禁用Canvas的根据画布大小调整缩放
            canvas.overridePixelPerfect = true;// 设置Canvas的计算顺序
        }

        public static void Edit_Text()
        {
            GameObject gameObject = new GameObject("name");
            GameObject parent = new GameObject("parent");
            if (parent) gameObject.transform.SetParent(parent.transform);
            Text textComponent = gameObject.AddComponent<Text>();
            textComponent.text = "Hello, World!";
            textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            textComponent.fontSize = 32;
            textComponent.color = Color.white;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.rectTransform.anchoredPosition = Vector2.zero;
            textComponent.rectTransform.sizeDelta = Vector2.one * 100f;
        }
        public static void Edit_Transform()
        {
            GameObject gameObject = new GameObject("gameObject");
            GameObject parentGameObject = new GameObject("parentGameObject");
            Transform transform = gameObject.transform;
            transform.position = new Vector3(1, 2, 3);//设置物体的世界坐标位置为(1, 2, 3)
            transform.localPosition = new Vector3(1, 2, 3);//设置物体的局部坐标位置为(1, 2, 3)
            transform.rotation = Quaternion.Euler(0, 45, 0);//设置物体的世界角度为(0, 45, 0)
            transform.localRotation = Quaternion.Euler(0, 45, 0);//设置物体的局部角度为(0, 45, 0)
            transform.localScale = new Vector3(2, 2, 2);//设置物体的缩放为(2, 2, 2)
            transform.SetParent(parentGameObject.transform);//设置物体的父级为parentTransform
            transform.Rotate(Vector3.up * Time.deltaTime);//绕Y轴每秒旋转1度
            transform.Translate(Vector3.forward * Time.deltaTime);//沿着Z轴方向移动
            transform.LookAt(new Vector3(0, 0, 0));//将物体朝向目标位置
            transform.GetChild(0);//获取物体的第一个子物体
            transform.Find("ChildObjectName");//通过子物体的名称查找子物体
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 30 * Time.deltaTime);//围绕某一点绕Y轴旋转
            transform.position += transform.forward * Time.deltaTime;//沿着物体的前方移动
        }
        public static void Edit_RectTransform()
        {
            GameObject gameObject = new GameObject("gameObject");
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = new Vector2(100, 100);//设置RectTransform的锚点位置为(100, 100)
            rectTransform.sizeDelta = new Vector2(200, 200);//设置RectTransform的尺寸为(200, 200)
            rectTransform.anchorMin = new Vector2(0, 0);//设置RectTransform的最小锚点位置为左下角
            rectTransform.anchorMax = new Vector2(1, 1);//设置RectTransform的最大锚点位置为右上角
            rectTransform.pivot = new Vector2(0.5f, 0.5f);//设置RectTransform的中心点为中心
            rectTransform.offsetMin = new Vector2(10, 10);//设置RectTransform的最小偏移量
            rectTransform.offsetMax = new Vector2(-10, -10);//设置RectTransform的最大偏移量
            rectTransform.localScale = new Vector3(2, 2, 2);//设置RectTransform的缩放为(2, 2, 2)
            rectTransform.ForceUpdateRectTransforms();//强制更新RectTransform及其子对象的布局
            rectTransform.SetAsLastSibling();//将RectTransform设置为最后一个兄弟节点
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);//根据当前锚点设置水平方向的尺寸为300
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 10, 100);// SetInsetAndSizeFromParentEdge 根据父对象边缘设置位置和大小
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 10, 50);// SetInsetAndSizeFromParentEdge 根据父对象边缘设置位置和大小
        }
    }
    public static class VLCreator
    {
        public static GameObject CreateAudioSource(string name = "AudioSource", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<AudioSource>();
            return gameObject;
        }
        public static GameObject CreateButton(string name = "Button", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<Image>();
            gameObject.AddComponent<Button>();
            var text = CreateText("Text", gameObject);
            var rectTransform = text.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 1f);
            rectTransform.offsetMin = new Vector2(0f, 0f);
            rectTransform.offsetMax = new Vector2(0f, 0f);
            return gameObject;
        }
        public static GameObject CreateCamera(string name = "Camera", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            var camera = gameObject.AddComponent<Camera>();
            return gameObject;
        }
        public static GameObject CreateCanvas(string name = "Canvas", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            var canvas = gameObject.AddComponent<Canvas>();
            var canvasScaler = gameObject.AddComponent<CanvasScaler>();
            var graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;// 设置Canvas的渲染模式为屏幕空间覆盖
            return gameObject;
        }
        public static GameObject CreateImage(Sprite sprite, string name = "Image", GameObject parent = null)
        {
            GameObject gameObject = CreateImage(name, parent);
            var image = gameObject.GetComponent<Image>();
            image.sprite = sprite;
            return gameObject;
        }
        public static GameObject CreateImage(string name = "Image", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<Image>();
            return gameObject;
        }
        public static GameObject CreatePanel(string name = "Panel", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            CanvasRenderer canvasRenderer = gameObject.AddComponent<CanvasRenderer>();//添加CanvasRenderer组件
            Image image = gameObject.AddComponent<Image>();//添加Image组件
            return gameObject;
        }
        public static GameObject CreateScrollView(string name = "ScrollView", GameObject parent = null)
        {
            Sprite spriteBackground = VLResource.Sprite_Background;
            Sprite spriteUIMask = VLResource.Sprite_UIMask;
            Sprite spriteUISprite = VLResource.Sprite_UISprite;

            // 添加 ScrollView
            GameObject gameObject = new GameObject(name);
            var image = gameObject.AddComponent<Image>();
            image.sprite = spriteBackground;
            image.type = Image.Type.Sliced;
            image.SetColorAlpha(0.4f);
            ScrollRect scrollRect = gameObject.AddComponent<ScrollRect>();
            scrollRect.horizontal = true;
            scrollRect.vertical = true;

            // 添加 Viewport
            GameObject viewportGO = new GameObject("Viewport");
            viewportGO.SetParent(gameObject);
            image = viewportGO.AddComponent<Image>();
            image.sprite = spriteUIMask;
            image.type = Image.Type.Sliced;
            Mask mask = viewportGO.AddComponent<Mask>();
            mask.showMaskGraphic = false;
            RectTransform maskRect = viewportGO.GetComponent<RectTransform>();
            maskRect.anchorMin = Vector2.zero;
            maskRect.anchorMax = Vector2.one;
            maskRect.sizeDelta = Vector2.zero;
            maskRect.pivot = new Vector2(0, 1);
            // 添加 Content
            GameObject contentGO = new GameObject("Content");
            contentGO.transform.SetParent(viewportGO.transform);
            var rectTransform = contentGO.AddComponent<RectTransform>();
            //rectTransform.anchorMin = new Vector2(0, 1);
            //rectTransform.anchorMax = new Vector2(1, 1);
            //rectTransform.pivot = new Vector2(0, 1);
            //rectTransform.sizeDelta = new Vector2(0, 300);
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.sizeDelta = new Vector2(1000, 1000);
            scrollRect.content = rectTransform;
            scrollRect.viewport = maskRect;

            // 添加 Scrollbar Horizontal
            var horizontalScrollbarGO = new GameObject("Scrollbar Horizontal");
            image = horizontalScrollbarGO.AddComponent<Image>();
            image.sprite = spriteBackground;
            image.type = Image.Type.Sliced;
            var horizontalScrollbar = horizontalScrollbarGO.AddComponent<Scrollbar>();
            horizontalScrollbar.transform.SetParent(gameObject.transform);
            RectTransform horizontalScrollbarRect = horizontalScrollbar.GetComponent<RectTransform>();
            horizontalScrollbarRect.anchorMin = new Vector2(0, 0);
            horizontalScrollbarRect.anchorMax = new Vector2(1, 0);
            horizontalScrollbarRect.offsetMin = new Vector2(0, 0);
            horizontalScrollbarRect.offsetMax = new Vector2(0, 0);
            horizontalScrollbarRect.pivot = new Vector2(0, 0);
            horizontalScrollbarRect.sizeDelta = new Vector2(0, 20);
            scrollRect.horizontalScrollbar = horizontalScrollbar;
            scrollRect.horizontalScrollbarSpacing = 0;// -3
            scrollRect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
            // 添加 Sliding Area
            var horizontalSlidingArea = new GameObject("Sliding Area");
            horizontalSlidingArea.SetParent(horizontalScrollbarGO);
            rectTransform = horizontalSlidingArea.AddComponent<RectTransform>();
            rectTransform.SetStretch(10, 10, 10, 10);
            // 添加 Handle
            var horizontalHandle = new GameObject("Handle");
            horizontalHandle.SetParent(horizontalSlidingArea);
            rectTransform = horizontalHandle.AddComponent<RectTransform>();
            //rectTransform.SetTopDown();
            //rectTransform.SetStretch(-10, -10, -10, -10);
            rectTransform.SetStretch(-18, -18, -10, -10);
            image = horizontalHandle.AddComponent<Image>();
            image.sprite = spriteUISprite;
            image.type = Image.Type.Sliced;
            horizontalScrollbar.targetGraphic = horizontalHandle.GetComponent<Image>();
            horizontalScrollbar.handleRect = horizontalHandle.GetComponent<RectTransform>();
            horizontalScrollbar.direction = Scrollbar.Direction.LeftToRight;

            //// 添加 Scrollbar Vertical
            var verticalScrollbarGO = new GameObject("Scrollbar Vertical");
            image = verticalScrollbarGO.AddComponent<Image>();
            image.sprite = spriteBackground;
            image.type = Image.Type.Sliced;
            var verticalScrollbar = verticalScrollbarGO.AddComponent<Scrollbar>();
            verticalScrollbar.transform.SetParent(gameObject.transform);
            RectTransform verticalScrollbarRect = verticalScrollbar.GetComponent<RectTransform>();
            verticalScrollbarRect.anchorMin = new Vector2(1, 0);
            verticalScrollbarRect.anchorMax = new Vector2(1, 1);
            verticalScrollbarRect.offsetMin = new Vector2(0, 0);
            verticalScrollbarRect.offsetMax = new Vector2(0, 0);
            verticalScrollbarRect.pivot = new Vector2(1, 1);
            verticalScrollbarRect.sizeDelta = new Vector2(20, 0);
            scrollRect.verticalScrollbar = verticalScrollbar;
            scrollRect.verticalScrollbarSpacing = 0;// -3
            scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
            // 添加 Sliding Area
            var verticalSlidingArea = new GameObject("Sliding Area");
            verticalSlidingArea.SetParent(verticalScrollbarGO);
            rectTransform = verticalSlidingArea.AddComponent<RectTransform>();
            rectTransform.SetStretch(10, 10, 10, 10);
            // 添加 Handle
            var verticalHandle = new GameObject("Handle");
            verticalHandle.SetParent(verticalSlidingArea);
            rectTransform = verticalHandle.AddComponent<RectTransform>();
            //rectTransform.SetLeftRight();
            //rectTransform.SetStretch(-10, -10, -10, -10);
            rectTransform.SetStretch(-10, -10, -18, -18);
            image = verticalHandle.AddComponent<Image>();
            image.sprite = spriteUISprite;
            image.type = Image.Type.Sliced;
            verticalScrollbar.targetGraphic = verticalHandle.GetComponent<Image>();
            verticalScrollbar.handleRect = verticalHandle.GetComponent<RectTransform>();
            verticalScrollbar.direction = Scrollbar.Direction.BottomToTop;
            verticalScrollbar.value = 1;

            return gameObject;
        }
        public static GameObject CreateSprite(string name = "Sprite", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<SpriteRenderer>();
            return gameObject;
        }
        public static GameObject CreateSquare(string name = "Square", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            gameObject.AddComponent<SpriteRenderer>();
            return gameObject;
        }
        public static GameObject CreateText(string name = "Sprite", GameObject parent = null)
        {
            GameObject gameObject = new GameObject(name);
            if (parent) gameObject.transform.SetParent(parent.transform);
            Text textComponent = gameObject.AddComponent<Text>();
            return gameObject;
        }
    }
    public static class VLCreaterPlus
    {
        public static GameObject ScrollViewGetContent(this GameObject ScrollView)
        {
            return ScrollView.transform.Find("Viewport").transform.Find("Content").gameObject;
        }
        public static void SetSizeDelta(this GameObject Content, Vector2 sizeDelta)
        {
            Content.GetComponent<RectTransform>().sizeDelta = sizeDelta;
        }
        public static GameObject CreateDialogue(string name = "dialogue", GameObject parent = null)
        {
            //Canvas
            var canvasGO = VLCreator.CreateCanvas(name, parent);
            var canvas = canvasGO.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.sortingOrder = (int)SortingOrder.AboveAll;
            var trans = canvasGO.GetComponent<RectTransform>();
            trans.anchorMin = new Vector3(0, 0);
            trans.anchorMax = new Vector3(0, 0);
            trans.anchoredPosition = new Vector2(0, 0.3f);
            trans.sizeDelta = new Vector2(1, 0.5f);
            if (parent) canvasGO.transform.SetParent(parent.transform);
            //Image
            var imageGO = VLCreator.CreateImage("dialogueImage", canvasGO);
            trans = imageGO.GetComponent<RectTransform>();
            trans.anchorMin = new Vector3(0, 0);
            trans.anchorMax = new Vector3(1, 1);
            trans.offsetMin = Vector2.zero;
            trans.offsetMax = Vector2.zero;
            trans.localPosition = Vector3.zero;
            var image = imageGO.GetComponent<Image>();
            image.color = "#050505".ToColor();
            var canvasGroup = imageGO.AddComponent<CanvasGroup>();
            canvasGroup.alpha = 0.8f;
            //Text
            var textGO = VLCreator.CreateText("dialogueText", imageGO);
            trans = textGO.GetComponent<RectTransform>();
            trans.anchorMin = new Vector3(0, 1);
            trans.anchorMax = new Vector3(0, 1);
            trans.sizeDelta = new Vector2(100, 0);
            trans.pivot = Vector3.zero;
            trans.localScale = new Vector3(0.01f, 0.01f);
            var text = textGO.GetComponent<Text>();
            text.color = Color.white;
            text.text = "123456789012345678901234567890123456";
            text.fontSize = 14;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.alignment = TextAnchor.UpperLeft;
            canvasGO.SetActive(true);
            return canvasGO;
        }
    }
}
