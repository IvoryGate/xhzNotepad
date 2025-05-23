const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  devServer:{
    host:'localhost',  // 本地主机
      port:8080,  // 端口号的配置
      open:true,  // 自动打开浏览器
      proxy:{
        '/api': {   //  拦截以 /api 开头的接口
          target: 'https://localhost:7053',//设置你调用的接口域名和端口号 别忘了加http
          changeOrigin: true,    //这里true表示实现跨域
          secure: false, // 如果是https接口，需要配置这个参数
          pathRewrite: {
            '^/api':'/'  //这里理解成用‘/api’代替target里面的地址，后面组件中我们掉接口时直接用api代替 比如我要调用'http://40.00.100.100:3002/api/user/add'，直接写‘/api/user/add’即可
          }
        }
    }
}
})
