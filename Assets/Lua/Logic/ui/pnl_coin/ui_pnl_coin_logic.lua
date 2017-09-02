local CUIBaseLogic = Import("logic/ui/base/ui_base_logic").CUIBaseLogic
local CUICoinView = Import("logic/ui/pnl_coin/ui_pnl_coin_view").CUICoinView
local EventDefine = Import("logic/base/event_define").Define

CUICoinLogic = class(CUIBaseLogic)

--构造函数，初始化View，绑定事件等
CUICoinLogic.Init = function(self, id)
    self._prefabPath = "Assets/Prefabs/ui/PanelCoin.prefab"
    self._view = CUICoinView:New(self._prefabPath)

	self._coinNum = 0				 -- 币数
	
	self._hasStart = false			 -- 是否进入游戏

	self._idleTime = 30				 -- 无操作进入待机视频时间	
	
	self._moveTexture = null		 -- 待机视频	
	
    CUIBaseLogic.Init(self, id)	
end

--绑定UI事件监听
CUICoinLogic.BindUIEvent = function(self)
    --编写格式如下:
		 
	--注册 IO消息
	IOLuaHelper.Instance:RegesterListener(1, LuaHelper.OnIOEventHandle(function() self:HandlerStart() end), "pnl_coin_start")
	IOLuaHelper.Instance:RegesterListener(2, LuaHelper.OnIOEventHandle(function() self:HandlerEnterSetting() end), "pnl_coin_setting")
	
end

CUICoinLogic.OnCreate = function(self)
	--注册币数和币率更改消息
	RegTrigger(EventDefine.COIN_DATA_COIN_CHANGE, function() self:RefreshCoinNum() end, "pnl_coin")
	--RegTrigger(EventDefine.COIN_DATA_RATE_CHANGE, function() self:RefreshRate() end, "pnl_coin")

    --后台数据
	self._settingData 			= gGame:GetDataMgr():GetSettingData()
	
	--打开界面更新界面数据
	self:RefreshCoinNum()
	self:RefreshRate()
	
	-- 待机倒计时
	self:UpdateIdleTime()
end

CUICoinLogic.OnDestroy = function(self)  
  --移除币数和币率更改消息
  UnRegTrigger(EventDefine.COIN_DATA_COIN_CHANGE, "pnl_coin")
  --UnRegTrigger(EventDefine.COIN_DATA_RATE_CHANGE, "pnl_coin")
  
  --移除 IO消息
  IOLuaHelper.Instance:RemoveListener(1, "pnl_coin_start")
  IOLuaHelper.Instance:RemoveListener(2, "pnl_coin_setting")
  
  GameObject.Destroy(self._view._root)   
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------- 被注册的方法 Begine--------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- 开始按钮
CUICoinLogic.HandlerStart = function(self, _listener, _args, _params)
	if self._settingData._hasCoin[1] >= self._settingData._rate and not self._hasStart then
		self._hasStart = true
		self._settingData:UseCoin()
		coroutine.start(ToSelect)
	end
	
	--local sequence = DG.Tweening.DOTween.Sequence()
	--sequence:Append(self._view._btnStart.transform:DOLocalMove(Vector3.New(0,0,0),2,false))
	--sequence:Append(self._view._btnAdd.transform:DOLocalMove(Vector3.New(0,0,0),2,false))
	--sequence:SetLoops(1, DG.Tweening.LoopType.Restart)
	--sequence:OnComplete(function() self:OnButtonMoveEnd() end)
end

--CUICoinLogic.OnButtonMoveEnd = function(self)
--	print("MoveEnd")
--end

-- 切换到后台太按钮
CUICoinLogic.HandlerEnterSetting = function(self, _listener, _args, _params)
	ioo.audioManager:StopBackMusic("Music_Idle_Start")
	gGame:ChangeSceneDirect("setting","settingScene")
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------  End	-----------------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------- 内部使用的方法 Begine------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- 刷新币数据
CUICoinLogic.RefreshCoinNum = function(self)
	self._view._coinNumber.text = self._settingData._hasCoin[1]

	if self._settingData._rate <= self._settingData._hasCoin[1] then
		self._view._needNumber.text = 0
		return
	end

	self._view._needNumber.text = self._settingData._rate - self._settingData._hasCoin[1]
end

-- 刷新币率
CUICoinLogic.RefreshRate = function(self)
	self._view._preNumber.text = self._settingData._rate
end

-- 进入地图选择
function ToSelect()
	coroutine.wait(2)
	gGame:GetSceneMgr():GetCurrentScene():ToSelect()
end

-- 无人操作倒计时
CUICoinLogic.UpdateIdleTime = function(self)
	self._idleTime = 30
	self._timerId = gGame:GetTimeMgr():AddTimer(1, function() 
		self._idleTime = self._idleTime - 1		
		if self._idleTime <= -1 then
			self:ToIdleMovie()
			gGame:GetTimeMgr():RemoveTimer(self._timerId)
		end			
	end, true)
end

-- 进入待机视频
CUICoinLogic.ToIdleMovie = function(self)
	if self._moveTexture ~= null then
		self._view._movie.Texture = self._moveTexture
		self._moveTexture.Play()
	else
		self.asset = ioo.resourceManager:LoadAsset("Assets/Movie/Idle0.mp4", MovieTexture.GetClassType())
		if asset ~= null then
			self._moveTexture:SetActive(true)
			self._moveTexture = (MovieTexture)(self.asset)
			self._view._movie.texture = self._moveTexture
			self._moveTexture.Play()
		end
	end
end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------  End	-----------------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
