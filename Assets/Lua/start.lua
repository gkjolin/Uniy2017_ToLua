--[[
local lang = ""
local re_str = "logic/lang/id_string_"..lang
if Util.IsFileExist(Util.LuaPath(re_str..".lua")) then
	loadfile(re_str)()
else
	id_string = nil
end
]]

loadfile("System/io")()
loadfile("System/class")()
loadfile("System/import")()

--require "base/jsonlib"
require "common/define"
require "common/functions"
require "common/event_trigger"
-- 载入定义全局
--Import("logic/common/global_enum")
--Import("logic/common/tool")

local CGame = Import("logic/game").CGame
local CControlManager = Import("logic/common/controller_manager").CControllerManager
--全局游戏
gGame = nil
--全局控制器切换
gControl = nil

GameManager = { }
GameManager.Awake = function()
    warn('Awake--->>>')
end

GameManager.Start = function()
    warn('Start--->>>')
end

GameManager.OnInitOK = function()
    log('OnInitOk--->>')
    UpdateBeat:Add(GameManager.Update)
    LateUpdateBeat:Add(GameManager.LateUpdate)
    FixedUpdateBeat:Add(GameManager.FixedUpdate)
    LevelWasLoad:Add(GameManager.OnLevelWasLoaded)
    gControl = CControlManager:New()
    gGame = CGame:New()
	
	--TODO: 放这里不一定合适 
	LoadSceneMgr.Instance:LoadJsonFile()
	
    --gGame:ChangeScene("login","loginScene")
    gGame:ChangeSceneDirect("coin","coinScene")
end

GameManager.XXXCall = function ()
    --warn('Can do some thing here');
    local tempScene = gGame:GetSceneMgr():GetCurrentScene()
    if tempScene.ShowEndResult ~= nil then
        tempScene:ShowEndResult()
    end
end

-- 销毁--
GameManager.OnDestroy = function()
    warn('OnDestroy--->>>');
end

GameManager.OnApplicationQuit = function()
    if gGame then
        gGame:OnApplicationQuit()
    end
end

GameManager.Update = function()
    if gGame then
        gGame:Update()
        gControl:Update()
    end
end

GameManager.LateUpdate = function()
    if gGame then
        gGame:LateUpdate()
        gControl:LateUpdate()
    end
end

GameManager.FixedUpdate = function()
    if gGame then
        gGame:FixedUpdate()
    end
end

GameManager.OnLevelWasLoaded = function()
    if gGame then
        gGame:OnLevelWasLoaded()
    end
end

GameManager.OnSocket = function(key, value)
    if gGame then
        gGame:OnSocket(key, value)
    end
end

--以下为输入点击的调用 lxt
GameManager.OnFingerDown = function(vec2, go)
    if gControl then
        gControl:OnFingerDown(vec2, go)
    end
end

GameManager.OnFingerHover = function(vec2, go, phase)
    if gControl then
        gControl:OnFingerHover(vec2, go, phase)
    end
end

GameManager.OnFingerMove = function(vec2, go, phase)
    if gControl then
        gControl:OnFingerMove(vec2, go, phase)
    end
end

GameManager.OnFingerStationary = function(vec2, go, phase)
    if gControl then
        gControl:OnFingerStationary(vec2, go, phase)
    end
end

GameManager.OnFingerUp = function(vec2, go)
    if gControl then
        gControl:OnFingerUp(vec2, go)
    end
end

GameManager.OnFirstFingerDrag = function(vec2, go, deltaMove, phase)
    if gControl then
        gControl:OnFirstFingerDrag(vec2, go, deltaMove, phase)
    end
end

GameManager.OnLongPress = function(vec2, go)
    if gControl then
        gControl:OnLongPress(vec2, go)
    end
end

GameManager.OnTap = function(vec2, go)
    if gControl then
        gControl:OnTap(vec2, go)
    end
end

GameManager.OnSwipe = function(vec2, go, startGO, velocity, move)
    if gControl then
        gControl:OnSwipe(vec2, go, startGO, velocity, move)
    end
end

GameManager.OnPinch = function(vec2, go, delta, gap, phase)
    if gControl then
        gControl:OnPinch(vec2, go, delta, gap, phase)
    end
end

GameManager.OnTwist = function(vec2, go, deltaRotation, totalRotation)
    if gControl then
        gControl:OnTwist(vec2, go, deltaRotation, totalRotation)
    end
end

collectgarbage("setpause", 180)
collectgarbage("setstepmul", 300)
