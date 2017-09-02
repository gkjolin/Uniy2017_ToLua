local Tool = Import("logic/common/tool").CTool
local SceneBase = Import("logic/modules/base_scene").CSceneBase 

local UIPnlCoinLogic = Import("logic/ui/pnl_coin/ui_pnl_coin_logic").CUICoinLogic
local UIPnlSelectLogic = Import("logic/ui/pnl_select/ui_pnl_select_logic").CUISelectLogic

-- Í¶±Ò³¡¾°
CCoinScene = class(SceneBase)

CCoinScene.Init = function(self)
	SceneBase.Init(self)
	
	self._coin = nil	
	
end


CCoinScene.OnLevelWasLoaded = function(self)
	self._camera = Camera.main
	self._hasEnterGame = false
	
	print("ChangeScene: Enter Coin Scene, ready to Coin!!!")
end

CCoinScene.OnUpdate = function(self)
	if self._hasEnterGame then return end
	self._hasEnterGame = true
	self._coin = gGame:GetUIMgr():CreateWindowCustom("coin", UIPnlCoinLogic)
	ioo.audioManager:PlayBackMusic("Music_Idle_Start", true)
end

CCoinScene.OnLateUpdate = function(self)
end

CCoinScene.OnFixedUpdate = function(self)
end


CCoinScene.OnApplicationQuit = function(self)
end

CCoinScene.OnDestroy = function(self)
	self._camera = nil
	
end


CCoinScene.ToSelect = function(self)
	ioo.audioManager:StopAll()
	gGame:GetUIMgr():CreateWindowCustom("select", UIPnlSelectLogic)
	gGame:GetUIMgr():DestroyWindow("coin")
end