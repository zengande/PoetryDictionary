const formatTime = date => {
    const year = date.getFullYear()
    const month = date.getMonth() + 1
    const day = date.getDate()
    const hour = date.getHours()
    const minute = date.getMinutes()
    const second = date.getSeconds()

    return [year, month, day].map(formatNumber).join('/') + ' ' + [hour, minute, second].map(formatNumber).join(':')
}

const formatNumber = n => {
    n = n.toString()
    return n[1] ? n : '0' + n
}

const loadFontFace = () => {
    if (wx.loadFontFace) {
        wx.loadFontFace({
            family: 'FangZheng',
            source: 'url("https://dictionary-1251959546.cos.ap-shanghai.myqcloud.com/FZFSK.TTF")',
            success: function() { console.log('load font success') }
        })
    } else {
        // 如果希望用户在最新版本的客户端上体验您的小程序，可以这样子提示
        wx.showModal({
            title: '提示',
            content: '当前微信版本过低，无法使用该功能，请升级到最新微信版本后重试。'
        })
    }
}

module.exports = {
    formatTime,
    loadFontFace
}