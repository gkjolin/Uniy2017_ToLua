CUICoinView = class()

--视图的构造函数，定义相关的变量并且初始化
CUICoinView.Init = function(self, prefabPath)

    self._root, self._asset = gGame:GetUIMgr():InitAsset(prefabPath)
	
    local rootTransform = self._root.transform
	
	self._coinNumber	= rootTransform:Find("Coin/CoinNumber"):GetComponent("Text")
	self._preNumber 	= rootTransform:Find("Coin/PreNumber"):GetComponent("Text")
	self._needNumber 	= rootTransform:Find("Need/NeedNumber"):GetComponent("Text")	

    self._root:SetActive(false)

end

