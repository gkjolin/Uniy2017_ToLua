CUISelectView = class()

--视图的构造函数，定义相关的变量并且初始化
CUISelectView.Init = function(self, prefabPath)
	self._root, self._asset = gGame:GetUIMgr():InitAsset(prefabPath)
	
	local rootTransform = self._root.transform
	
	self._maps = {}
	local count = rootTransform:Find("Maps").transform.childCount
	for i = 0, count - 1 do
		self._maps[i]	= rootTransform:Find("Maps/Map"..i):GetComponent("Image")
	end
end