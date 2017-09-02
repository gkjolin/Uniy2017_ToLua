local EventDefine = Import("logic/base/event_define").Define
local EventSource = Import("logic/common/event_source").EventSource

CSettingData = class()

CSettingData.Init = function(self)	
	self._maxRate 		= 6
	self._maxVolume 	= 10
	self._maxLevel 		= 3
	self._maxLanguage 	= 2

	self._hasCoin 	= SettingManager.Instance.HasCoin
	self._rate 		= SettingManager.Instance.GameRate
	self._volume	= SettingManager.Instance.GameVolume
	self._level		= SettingManager.Instance.GameLevel
	self._language  = SettingManager.Instance.GameLanguage
	
	--注册 Keyboard消息
	IOLuaHelper.Instance:RegesterListener(0, LuaHelper.OnIOEventHandle(function(id, value) self:AddCoin(id, value) end), "setting_data_coin")
end

--修改币率
CSettingData.SetGameRate = function(self, _value)
	self._rate = _value
	SettingManager.Instance.GameRate = self._rate
	self:Save()	
end

--修改音量
CSettingData.SetGameVolume = function(self, _volume)
	 self._volume = _volume
	 SettingManager.Instance.GameVolume = self._volume
	 self:Save()
end

--修改难度
CSettingData.SettGameLevel = function(self, _level)
	 self._level = _level
	 SettingManager.Instance.GameVolume = self._level
	 self:Save()
end

--修改游戏语言
CSettingData.SetGameLanguage = function(self, _language)
print(_language)
	 self._language = _language
	 SettingManager.Instance.GameLanguage = self._language
	 self:Save()
	 EventTrigger(EventDefine.Setting_Data_Language)
end

--修改出票模式
CSettingData.SetGameTicket = function(self, _ticket)

end

--清除投币
CSettingData.ClearCoin = function(self)
	for i = 0, self._hasCoin.Length - 1 do
		self._hasCoin[i] = 0
	end
	SettingManager.Instance:ClearCoin()
	self:Save()
end

--清除查账
CSettingData.ClearAccount = function(self)
	SettingManager.Instance:ClearMonthInfo()
	SettingManager.Instance:ClearTotalRecord()
	self:Save()
	EventTrigger(EventDefine.Setting_Data_Language)
end

-- 币数变化
CSettingData.AddCoin = function(self, id) 	
	ioo.audioManager:PlaySound2D("SFX_Voice_Sound_Change")
	self._hasCoin[id+1] = self._hasCoin[id+1] + 1
	if self._hasCoin[id + 1] >= 99 then
		self._hasCoin[id + 1] = 99
	end
	SettingManager.Instance:AddCoin(id)
	self:Save() 
	EventTrigger(EventDefine.COIN_DATA_COIN_CHANGE)
end

-- 使用游戏币
CSettingData.UseCoin = function(self)
	ioo.audioManager:PlaySound2D("SFX_Voice_Sound_Sure")
	self._hasCoin[1] = self._hasCoin[1] - self._rate
	SettingManager.Instance.HasCoin = self._hasCoin	
	SettingManager.Instance:LogNumberOfGame(1)
	self:Save()
	EventTrigger(EventDefine.COIN_DATA_COIN_CHANGE)
end

--保存到本地
CSettingData.Save = function(self)
	SettingManager.Instance:Save()
end


CSettingData.ClearALL = function(self)
 --移除 Keyboard消息
  IOLuaHelper.Instance:RemoveListener(0, "pnl_coin_coin")
end