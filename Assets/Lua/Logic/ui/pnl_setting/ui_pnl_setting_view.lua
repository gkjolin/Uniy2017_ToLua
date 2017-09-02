CUISettingView = class()

--��ͼ�Ĺ��캯����������صı������ҳ�ʼ��
CUISettingView.Init = function(self, prefabPath)

    self._root, self._asset = gGame:GetUIMgr():InitAsset(prefabPath)
	
    local rootTransform = self._root.transform
	
	-- ���ҳ�����
	self._page 				= {}
	self._pageCount			= rootTransform.childCount
	
	-- ��ҳ
	self._homePage 			= rootTransform:Find("HomePage")	
	self._page[0]			= self._homePage		
	self._homeLable 		= {}
	self._homeCheckMark 	= {}
	local cout 				= self._homePage.transform.childCount
	for i = 0, cout - 1 do
		self._homeLable[i] 		= self._homePage.transform:Find("Toggle"..i.."/Label"):GetComponent("Text")
		self._homeCheckMark[i] 	= self._homePage.transform:Find("Toggle"..i.."/Checkmark")
	end
	
	--����ҳ
	self._setPage			= rootTransform:Find("SettingPage")
	self._page[1]			= self._setPage		
	self._setLable 			= {}
	self._setValue			= {}
	self._setCheckMark      = {}
	self._setMain			= self._setPage.transform:Find("Main")
	cout 					= self._setPage.transform:Find("Main/Setting").transform.childCount
	for i = 0, cout - 1 do
		self._setCheckMark[i] 	= self._setPage.transform:Find("Main/Setting/Toggle"..i.."/Checkmark")
		self._setLable[i]		= self._setPage.transform:Find("Main/Setting/Toggle"..i.."/Key"):GetComponent("Text")
		self._setValue[i]		= self._setPage.transform:Find("Main/Setting/Toggle"..i.."/Value"):GetComponent("Text")
	end
	
	-- ��ҳ
	self._shotPage			= self._setPage.transform:Find("ShotPage")

	--����ҳ
	self._accountPage		= rootTransform:Find("AccountPage")
	self._page[2]			= self._accountPage
	self._accountLable		= {}
	self._accountCheckMark  = {}
	self._accountMain		= self._accountPage.transform:Find("Main")
	cout 					= self._accountPage.transform:Find("Main").transform.childCount
	for i = 0, cout - 1 do
		self._accountLable[i] 		= self._accountPage.transform:Find("Main/Toggle"..i.."/Label"):GetComponent("Text")
		self._accountCheckMark[i] 	= self._accountPage.transform:Find("Main/Toggle"..i.."/Checkmark")
	end
	
	-- ��ҳ �ܼ�¼
	self._totalPage			= self._accountPage.transform:Find("TotalAccount")
	self._totalKeys			= {}
	self._totalValues		= {}
	cout					= self._totalPage.transform:Find("Key").transform.childCount
	for i = 0, cout - 1 do
		self._totalKeys[i]  = self._totalPage.transform:Find("Key/Key"..i):GetComponent("Text")
		self._totalValues[i]= self._totalPage.transform:Find("Value/Value"..i):GetComponent("Text")
	end
	
	-- ��ҳ �����¼
	self._account			= self._accountPage.transform:Find("Account")
	self._accountKeys		= {}
	self._accountValues		= {}
	
	cout					= self._account.transform:Find("Key").transform.childCount
	for i = 0, cout - 1 do
		self._accountKeys[i] = self._account.transform:Find("Key/Key"..i):GetComponent("Text")		
	end
	
	cout					= self._account.transform:Find("Value").transform.childCount
	for i = 0, cout - 1 do
		self._accountValues[i] = {}
		for j = 0, 4 do
			self._accountValues[i][j] = self._account.transform:Find("Value/Item"..i.."/Value"..j):GetComponent("Text")
		end
	end
		
    self._root:SetActive(false)

end

