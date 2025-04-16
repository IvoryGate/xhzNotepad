<template>
  <div class="container-input">
    <input
    @keyup.enter="itemPush"
    v-model="toInput" 
    type="text"
    placeholder="请输入任务名称">
    <button @click="itemPush">添加任务</button>
  </div>
</template>

<script>
export default {
data(){
  return{
    toInput:''
  }
},
methods:{
  itemPush(){
    if(this.toInput===''){
      alert('任务名不能为空');
      return
    }
    this.$emit('add',this.toInput);
    this.toInput='';
  }
}
}
</script>

<style scoped>
.container-input{
    width: 100%;
    border: 2px solid;
    border-radius: 10px;
    height: 50px;
    overflow: hidden;
}
input{
    display: block;
    border: none;
    outline: 0;
    float: left;
    width: 70%;
    font-size: 20px;
    box-sizing: border-box;
    padding: 15px 5%;
    font-family: 'Times New Roman', Times, serif;
}
button{
    border: none;
    display: block;
    background-color: green;
    height: 100%;
    margin-top: 0;
    width: 30%;
    font-size: 20px;
    font-family: 'Times New Roman', Times, serif;
    cursor: pointer;
}
button:hover{
    color: white;
}
</style>