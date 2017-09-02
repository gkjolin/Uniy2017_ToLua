local Tool = Import("logic/common/tool").CTool
local SceneBase = Import("logic/modules/base_scene").CSceneBase 

CBattleScene = class(SceneBase)

CBattleScene.Init = function(self)
	SceneBase.Init(self)
	
	self._coin = nil
end


CBattleScene.OnLevelWasLoaded = function(self)
	self._camera = Camera.main
	self._hasEnterGame = false
	print("ChangeScene: Enter Battle Scene, ready to Battle")
end

CBattleScene.OnUpdate = function(self)
	if self._hasEnterGame then return end
	self._hasEnterGame = true
	--self._coin = gGame:GetUIMgr():CreateWindowCustom("coin", UIPnlCoinLogic)
	ioo.audioManager:PlayBackMusic("Music_Scene", true)
end

CBattleScene.OnLateUpdate = function(self)
end

CBattleScene.OnFixedUpdate = function(self)
end


CBattleScene.OnApplicationQuit = function(self)
end

CBattleScene.OnDestroy = function(self)
	ioo.audioManager:StopBackMusic("Music_Idle_Start")
end

-- 预加载
CBattleScene.SetPreLoad = function(self)
	LoadSceneMgr.Instance:AddPreLoadPrefab("Cube", 5)
	LoadSceneMgr.Instance:AddPreLoadPrefab("Cylinder", 5)
end