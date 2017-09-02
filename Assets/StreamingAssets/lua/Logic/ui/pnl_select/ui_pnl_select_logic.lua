local CUIBaseLogic = Import("logic/ui/base/ui_base_logic").CUIBaseLogic
local CUISelectView = Import("logic/ui/pnl_select/ui_pnl_select_view").CUISelectView
local EventDefine = Import("logic/base/event_define").Define

CUISelectLogic = class(CUIBaseLogic)

-- 构造函数，初始化View，绑定函数
CUISelectLogic.Init = function(self, id)
	self._prefabPath = "Assets/Prefabs/ui/PanelSelect.prefab"
	self._view = CUISelectView:New(self._prefabPath)
	
	self._selectID = 0
	self._grey = nil
	self._normal = nil
	
	CUIBaseLogic.Init(self, id)
end

-- 绑定UI事件监听
CUISelectLogic.BindUIEvent = function(self)
	--注册 IO消息
	IOLuaHelper.Instance:RegesterListener(1, LuaHelper.OnIOEventHandle(function() self:HandleSure() end), "pnl_select_sure")
	IOLuaHelper.Instance:RegesterListener(4, LuaHelper.OnIOEventHandle(function() self:HandleLeft() end), "pnl_select_left")
	IOLuaHelper.Instance:RegesterListener(5, LuaHelper.OnIOEventHandle(function() self:HandleRight() end), "pnl_select_right")
end

-- 创建
CUISelectLogic.OnCreate = function(self)

	self._grey 		= Util.CreateMat("Assets/Shaders/Proj/Effect/effect_ui_grey.shader")
	self._normal 	= Util.CreateMat("Assets/Shaders/Unity/DefaultResourcesExtra/Mobile/Mobile-Particle-Alpha.shader")
	self:OnSelect()	
end

-- 销毁
CUISelectLogic.OnDestroy = function(self)
	-- 移除 IO消息
	IOLuaHelper.Instance:RemoveListener(1, "pnl_select_sure")
	IOLuaHelper.Instance:RemoveListener(4, "pnl_select_left")
	IOLuaHelper.Instance:RemoveListener(5, "pnl_select_right")
	
	GameObject.Destroy(self._view._root)   
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------- 被注册的方法 Begine--------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- 左操作
CUISelectLogic.HandleLeft = function(self)
	self._selectID = self._selectID - 1
	if self._selectID < 0 then
		self._selectID = self._selectID + #self._view._maps + 1
	end

	self._selectID = math.mod(self._selectID, #self._view._maps + 1)
	self:OnSelect()
end

-- 右操作
CUISelectLogic.HandleRight = function(self)
	self._selectID = self._selectID + 1
	self._selectID = math.mod(self._selectID, #self._view._maps + 1)
	self:OnSelect()
end

-- 确认操作
CUISelectLogic.HandleSure = function(self)
	gGame:ChangeScene("battle", "battleScene")
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------  End	-----------------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- 被选中的地图
CUISelectLogic.OnSelect = function(self)
	for i = 0, #self._view._maps do
		if i ~= self._selectID then
			self._view._maps[i].material = self._grey
			local sequence = DG.Tweening.DOTween.Sequence()
			sequence:Append(self._view._maps[i].transform:DOScale(Vector3.New(1,1,1) * 0.5, 0.1))
			sequence:SetLoops(1, DG.Tweening.LoopType.Restart)
		else
			self._view._maps[i].material = self._normal
			local sequence = DG.Tweening.DOTween.Sequence()
			sequence:Append(self._view._maps[i].transform:DOScale(Vector3.New(1,1,1) * 0.6, 0.1))
			sequence:SetLoops(1, DG.Tweening.LoopType.Restart)
			--sequence:OnComplete(function() self:OnButtonMoveEnd() end)
		end
	end	
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------- 内部使用的方法 Begine------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------  End	-----------------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------