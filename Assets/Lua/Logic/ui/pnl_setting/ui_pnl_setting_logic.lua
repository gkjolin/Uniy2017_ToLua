local CUIBaseLogic = Import("logic/ui/base/ui_base_logic").CUIBaseLogic
local CUISettingView = Import("logic/ui/pnl_setting/ui_pnl_setting_view").CUISettingView
local EventDefine = Import("logic/base/event_define").Define
local SettingDefine = Import("logic/base/setting_define").Define
local Tool = Import("logic/common/tool").CTool

CUISettingLogic = class(CUIBaseLogic)

--���캯������ʼ��View�����¼���
CUISettingLogic.Init = function(self, id)
    self._prefabPath = "Assets/Prefabs/ui/PanelSetting.prefab"
    self._view = CUISettingView:New(self._prefabPath)
	
	-- 0����ҳ 1������ҳ 2������ҳ
	self._curPage = 0
	-- ��ǰҳѡ����
	self._index = 0
	-- ����
	self._lock = false
	
    CUIBaseLogic.Init(self, id)	
end

--��UI�¼�����
CUISettingLogic.BindUIEvent = function(self)
	--ע�� IO��Ϣ
	IOLuaHelper.Instance:RegesterListener(2, LuaHelper.OnIOEventHandle(function() self:HandleButtonA() end), "pnl_setting_A")
	IOLuaHelper.Instance:RegesterListener(3, LuaHelper.OnIOEventHandle(function() self:HandleButtonB() end), "pnl_setting_B")
	
	--ע�����Ը�����Ϣ
	RegTrigger(EventDefine.Setting_Data_Language, function() self:RefreshSetInfo() end, "pnl_setting")
end

CUISettingLogic.OnCreate = function(self)
	self._settingData = gGame:GetDataMgr():GetSettingData()
   
	self._rate 		= self._settingData._rate
	self._hasCoin 	= self._settingData._hasCoin
	self._rate 		= self._settingData._rate
	self._volume	= self._settingData._volume
	self._level		= self._settingData._level
	self._language  = self._settingData._language
	self._clearCoin		= false
	self._clearAccount	= false
	self:RefreshSetInfo()
end

CUISettingLogic.OnDestroy = function(self)
   --�Ƴ� IO��Ϣ
   IOLuaHelper.Instance:RemoveListener(2, "pnl_setting_A")
   IOLuaHelper.Instance:RemoveListener(3, "pnl_setting_B")
  
   --�Ƴ����Ը�����Ϣ
   RegTrigger(EventDefine.Setting_Data_Language, "pnl_setting")
  
   GameObject.Destroy(self._view._root)
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------- ��ע��ķ��� Begine--------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--���ð�ťA����
CUISettingLogic.HandleButtonA = function(self)
	-- ��ҳ
	if self._curPage == 0 then
		self:OPInHomePage_A()
	-- ����ҳ
	elseif self._curPage == 1 then
		self:OPInSetPage_A()
	-- ����ҳ
	elseif self._curPage == 2 then
		self:OPAccountPage_A()
	else
	
	end
end

--���ð�ťB����
CUISettingLogic.HandleButtonB = function(self)
	if not self._lock then
		self._index = self._index + 1
		-- ��ҳ
		if self._curPage == 0 then
			self._index = self._index % (#self._view._homeCheckMark + 1)
		-- ����ҳ
		elseif self._curPage == 1 then
			if self._view._setMain.gameObject.activeSelf then
				self._index = self._index % (#self._view._setCheckMark + 1)
			end			
		elseif self._curPage == 2 then
			self._index = self._index % (#self._view._accountCheckMark + 1)		
		end
		
		self:SelectPageItem()
		
	-- Ŀǰ������ѡ���ҳ��ֻ������ҳ��
	else
	    -- ����
		if self._index == 0 then
			self._rate = self._rate + 1
			self._rate = self._rate % self._settingData._maxRate			
			self._settingData:SetGameRate(self._rate)
			self._view._setValue[self._index].text = self._rate
		-- ����
		elseif self._index == 1 then
			self._volume = self._volume + 1			
			self._volume = self._volume % self._settingData._maxVolume			
			self._settingData:SetGameVolume(self._volume)
			self._view._setValue[self._index].text = self._volume
		-- �Ѷ�
		elseif self._index == 2 then
			self._level = self._level + 1
			self._level = self._level % self._settingData._maxLevel
			self._settingData:SettGameLevel(self._level)
			self._view._setValue[self._index].text = self._level
		-- ����
		elseif self._index == 3 then
			self._language = self._language + 1
			self._language = self._language % self._settingData._maxLanguage
			self._settingData:SetGameLanguage(self._language)
			self._view._setValue[self._index].text = SettingDefine.Lanauage[self._language]
		-- ��Ʊ
		elseif self._index == 4 then
			
		-- ������� Ͷ��
		elseif self._index == 5 then
			self._clearCoin = not self._clearCoin
			if self._clearCoin then
				self._view._setValue[self._index].text = SettingDefine.YesNo[self._language][0]
			else
				self._view._setValue[self._index].text = SettingDefine.YesNo[self._language][1]
			end			
		elseif self._index == 6 then
			self._clearAccount = not self._clearAccount
			if self._clearAccount then
				self._view._setValue[self._index].text = SettingDefine.YesNo[self._language][0]
			else
				self._view._setValue[self._index].text = SettingDefine.YesNo[self._language][1]
			end			
		end
	end
	
end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------  End	-----------------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------- �ڲ�ʹ�õķ��� Begine------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- ��ҳA����
CUISettingLogic.OPInHomePage_A = function(self)
	if self._index == 0 then
		self._curPage = 1
		self:ShowPage()
	elseif self._index == 1 then
		self._curPage = 2
		self:ShowPage()
	else
		self._curPage 	= 0
		self._index 	= 0
		self:Exit()
	end
end

-- ����ҳA����
CUISettingLogic.OPInSetPage_A = function(self)
	if self._index < #self._view._setLable - 3 then
		self._lock = not self._lock
		self:SetSelectItemColor()	
	elseif self._index == #self._view._setLable - 3 then
		self._lock = not self._lock
		self:SetSelectItemColor()	
		if self._clearCoin and not self._lock then
			self._settingData:ClearCoin()
		end
	elseif self._index == #self._view._setLable - 2 then
		self._lock = not self._lock
		self:SetSelectItemColor()
		if self._clearAccount and not self._lock then
			self._settingData:ClearAccount()
		end
	else
		-- ���У��ҳ
		if self._index == #self._view._setCheckMark - 1 then
			self._view._page[self._curPage].gameObject:SetActive(false)
			self._view._shotPage.gameObject:SetActive(true)
		-- ������ҳ
		else
			self._curPage = 0
			self:ShowPage()
		end
	end
end

-- ����ҳA����
CUISettingLogic.OPAccountPage_A = function(self)
	if self._view._accountMain.gameObject.activeSelf then
		if self._index == 0 then
			self._view._accountMain.gameObject:SetActive(false)
			self._view._account.gameObject:SetActive(true)
		elseif self._index == 1 then
			self._view._accountMain.gameObject:SetActive(false)
			self._view._totalPage.gameObject:SetActive(true)
		else
			self._curPage = 0
			self:ShowPage()
		end
	elseif self._view._account.gameObject.activeSelf then
		self._view._accountMain.gameObject:SetActive(true)
		self._view._account.gameObject:SetActive(false)
	else
		self._view._accountMain.gameObject:SetActive(true)
		self._view._totalPage.gameObject:SetActive(false)
	end	
end

--��ʾָ��ҳ�棨��ҳ�棬����ҳ�棬����ҳ�棩
CUISettingLogic.ShowPage = function(self)
	self._index = 0
	for i = 0, #self._view._page do
		if i == self._curPage then
			self._view._page[i].gameObject:SetActive(true)
		else
			self._view._page[i].gameObject:SetActive(false)
		end
	end
	
	-- �л�ҳ������õ�ǰѡ��
	self:SelectPageItem()
end

--�л���ǰҳ��ǰ��
CUISettingLogic.SelectPageItem = function(self)
	if self._curPage == 0 then
		for i = 0, #self._view._homeCheckMark do
			if self._index == i then
				self._view._homeCheckMark[i].gameObject:SetActive(true)
			else
				self._view._homeCheckMark[i].gameObject:SetActive(false)
			end
		end
	elseif self._curPage == 1 then
		for i = 0, #self._view._setCheckMark do
			if self._index == i then
				self._view._setCheckMark[i].gameObject:SetActive(true)
			else
				self._view._setCheckMark[i].gameObject:SetActive(false)
			end
		end
	else
		if self._view._setMain.gameObject.activeSelf then
			for i = 0, #self._view._accountCheckMark do
				if self._index == i then
					self._view._accountCheckMark[i].gameObject:SetActive(true)
				else
					self._view._accountCheckMark[i].gameObject:SetActive(false)
				end
			end
		end
	end
	
end

--�������ҳ������
CUISettingLogic.RefreshSetInfo = function(self)
	local Setting 	=	{}
	if self._settingData._language == 0 then
		Setting = SettingDefine.Chinese
	else 
		Setting = SettingDefine.English
	end
	 
	-- ��ҳ 
	for i = 0, #self._view._homeLable do
		self._view._homeLable[i].text = Setting["homePage"][i]
	end
	
	-- ����ҳ
	for i = 0, #self._view._setLable do
		self._view._setLable[i].text = Setting["setPage"][i]
	end
	
	-- ����ҳ
	for i = 0, #self._view._accountLable do
		self._view._accountLable[i].text = Setting["account"][i]
	end
	
	-- ������ҳ��-�ܼ�¼
	for i= 0, #self._view._totalKeys do
		self._view._totalKeys[i].text = Setting["total"][i]
	end
	
	-- ������ҳ��-���ڼ�¼
	for i = 0, #self._view._accountKeys do
		self._view._accountKeys[i].text = Setting["recent"][i]
	end
	
	self._view._setValue[0].text = self._rate
	self._view._setValue[1].text = self._volume
	self._view._setValue[2].text = self._level
	self._view._setValue[3].text = SettingDefine.Lanauage[self._language]
	if self._clearCoin then
				self._view._setValue[5].text = SettingDefine.YesNo[self._language][0]
			else
				self._view._setValue[5].text = SettingDefine.YesNo[self._language][1]
	end		

	if self._clearAccount then
				self._view._setValue[6].text = SettingDefine.YesNo[self._language][0]
			else
				self._view._setValue[6].text = SettingDefine.YesNo[self._language][1]
	end		 
	
	
	--TODO: ������Ϣ��������
	---��������¼�¼
	local monthRecord = SettingManager.Instance:GetMonthData()
	for i = 0, monthRecord.Count - 1 do
		for j = 0, #self._view._accountValues[i] do
			if j == 0 or j == 1 or j == 2 then
				self._view._accountValues[i][j].text = monthRecord[i][j]
			else
				self._view._accountValues[i][j].text = Tool.Sec2String(monthRecord[i][j])
			end
		end
	end
	
	--�ܼ�¼��Ϣ
	local totalRecord = SettingManager.Instance:TotalRecord()
	for i = 0, #self._view._totalValues do
		if i == 1 or i == 2 then
			self._view._totalValues[i].text = Tool.Sec2String(totalRecord[i])
		else
			self._view._totalValues[i].text = totalRecord[i]
		end		
	end
end

CUISettingLogic.SetSelectItemColor = function(self)
	if self._lock then
		for i = 0, #self._view._setLable - 2 do
			if i == self._index then
				self._view._setLable[i].color = Color.red
			else
				self._view._setLable[i].color = Color.black
			end
		end
	else
		for i = 0, #self._view._setLable - 2 do			
			self._view._setLable[self._index].color = Color.black
		end
	end
		
end

--�˳���̨
CUISettingLogic.Exit = function(self, _listener, _args, _params)
	gGame:ChangeSceneDirect("coin", "coinScene")
end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------  End	-----------------------------------------------------------------------------				
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------