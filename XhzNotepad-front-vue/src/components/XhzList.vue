<template>
  <div class="container-list">
    <li v-for="(item,index) in list" :key="item.id">
        <div class="view">
            <span class="index">{{ index + 1 }}.</span>
            <label for="">{{ item.task1 }}</label>
            <button @click="itemRemove(item.id)" class="delete">删除</button>
        </div>
    </li> 
  </div>
</template>

<script>
export default {
    // props:['list'],
    props:{
        list:Array
    },
    methods:{
        itemRemove(id){
            this.$emit('remove',id)
        }
    }
}
</script>

<style scoped>
li{
    list-style-type: none;
    width: 100%;
    height: 40px;
}
.view{
    height: 100%;
}
span{
    width: 5%;
    box-sizing: border-box;
    float: left;
    height: 100%;
    margin-left: 10px;
    padding-top: 7px;
    font-size: 20px;
}
button{
    width: 15%;
    display: block;
    float: right;
    padding-left: 10px;
    border: none;
    background: none;
    height: 100%;
    font-size: 20px;
    cursor: pointer;
}
.view:hover span{
    color: red;
}
.view:hover label{
    color: red;
}
.view:hover button{
    color: red;
}

label{
    white-space: nowrap;
    overflow:hidden;
    max-width: 75%;
    box-sizing: border-box;
    display: block;
    float: left;
    height: 40px;
    padding: 9px;
    line-height: 100%;
    font-size: 20px;
}
</style>