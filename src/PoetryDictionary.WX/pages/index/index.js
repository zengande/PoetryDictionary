//index.js
//获取应用实例
const app = getApp()

Page({
  data: {
    motto: '方正仿宋',
    userInfo: {},
    hasUserInfo: false,
    canIUse: wx.canIUse('button.open-type.getUserInfo'),
    dates: [{
      id: 1,
      date: '2019-05-16',
      poetry: {
        content: ["人生若只如初见", "何事秋风悲画扇"],
        author: "朝·诗人",
        source: "来源名称"
      },
      week: '星期四',
      day: 16,
      lunarcalendar: {
        zodiac: '猪',
        year: '己亥年',
        month: '己巳月',
        day: '癸丑日'
      }
    }, {
      id: 2,
      date: '2019-05-17',
      poetry: {
        content: ["人生若只如初见", "何事秋风悲画扇"],
        author: "朝·诗人",
        source: "来源名称"
      },
      week: '星期五',
      day: 17,
      lunarcalendar: {
        zodiac: '猪',
        year: '己亥年',
        month: '己巳月',
        day: '甲寅日'
      }
    }, {
      id: 3,
      date: '2019-05-18',
      poetry: {
        content: ["人生若只如初见", "何事秋风悲画扇"],
        author: "朝·诗人",
        source: "来源名称"
      },
      week: '星期五',
      day: 17,
      lunarcalendar: {
        zodiac: '猪',
        year: '己亥年',
        month: '己巳月',
        day: '乙卯日'
      }
    }, {
      id: 4,
      date: '2019-05-19',
      poetry: {
        content: ["人生若只如初见", "何事秋风悲画扇"],
        author: "朝·诗人",
        source: "来源名称"
      },
      week: '星期五',
      day: 17,
      lunarcalendar: {
        zodiac: '猪',
        year: '己亥年',
        month: '己巳月',
        day: '丙辰日'
      }
    }, {
      id: 5,
      date: '2019-05-20',
      poetry: {
        content: ["人生若只如初见", "何事秋风悲画扇"],
        author: "朝·诗人",
        source: "来源名称"
      },
      week: '星期五',
      day: 17,
      lunarcalendar: {
        zodiac: '猪',
        year: '己亥年',
        month: '己巳月',
        day: '丁巳日'
      }
    }, {
      id: 6,
      date: '2019-05-21',
      poetry: {
        content: ["人生若只如初见", "何事秋风悲画扇"],
        author: "朝·诗人",
        source: "来源名称"
      },
      week: '星期五',
      day: 17,
      lunarcalendar: {
        zodiac: '猪',
        year: '己亥年',
        month: '己巳月',
        day: '戊午日'
      }
    }, {
      id: 7,
      date: '2019-05-22',
      poetry: {
        content: ["人生若只如初见", "何事秋风悲画扇"],
        author: "朝·诗人",
        source: "来源名称"
      },
      week: '星期五',
      day: 17,
      lunarcalendar: {
        zodiac: '猪',
        year: '己亥年',
        month: '己巳月',
        day: '己未日'
      }
    }]
  },
  //事件处理函数
  bindViewTap: function() {
    wx.navigateTo({
      url: '../logs/logs'
    })
  },
  onLoad: function() {
    if (app.globalData.userInfo) {
      this.setData({
        userInfo: app.globalData.userInfo,
        hasUserInfo: true
      })
    } else if (this.data.canIUse) {
      // 由于 getUserInfo 是网络请求，可能会在 Page.onLoad 之后才返回
      // 所以此处加入 callback 以防止这种情况
      app.userInfoReadyCallback = res => {
        this.setData({
          userInfo: res.userInfo,
          hasUserInfo: true
        })
      }
    } else {
      // 在没有 open-type=getUserInfo 版本的兼容处理
      wx.getUserInfo({
        success: res => {
          app.globalData.userInfo = res.userInfo
          this.setData({
            userInfo: res.userInfo,
            hasUserInfo: true
          })
        }
      })
    }
  },
  getUserInfo: function(e) {
    console.log(e)
    app.globalData.userInfo = e.detail.userInfo
    this.setData({
      userInfo: e.detail.userInfo,
      hasUserInfo: true
    })
  }
})