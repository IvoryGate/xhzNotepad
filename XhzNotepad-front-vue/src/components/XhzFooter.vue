<template>
  <div class="container-footer">
    <span style="margin-left: 10px;">合计：</span>
    <span class="total">{{ list.length }}</span>
    <button @click="clearAll" class="clear">清空任务</button>
  </div>
</template>

<script>
export default {
  props:{
    list:Array
  },
  methods:{
    clearAll(){
      this.$emit('clc')
    }
  }
}
</script>

<style scoped>
.container-footer{
    width: 100%;
    border-top: 1px solid;
    height: 20px;
    margin-top: 10px;
}
span{
    display: block;
    float: left;
    height: 30px;
    font-size: 15px;
    margin-top: 5px;
}
.clear{
    padding: 0;
    float: right;
    background: none;
    border:none;
    font-size: 15px;
    margin-top: 5px;
    margin-right: 10px;
    cursor: pointer;
}
.container-footer:hover .clear{
  color:red;
}
</style>