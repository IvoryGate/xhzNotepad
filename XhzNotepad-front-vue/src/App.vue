<template>
  <div class="app">
    <div class="main">
      <XhzTitle></XhzTitle>
      <XhzInput @add="handleAdd"></XhzInput>
      <XhzList :list="mylist" @remove="haddleRemove"></XhzList>
      <XhzFooter :list="mylist" @clc="handleClear"></XhzFooter>
    </div>
    <div class="behind-one"></div>
    <div class="behind-two"></div>
  </div>
</template>
<style>
*{
  margin: 0;
  padding: 0;
}
.app{
  position: absolute;
  width: 80%;
  left:50%;
  transform: translate(-50%,50px);
  min-width: 400px;
  max-width: 800px;
}
.main{
  position: relative;
  background-color: rgb(238, 227, 210);
  padding: 20px;
  border-radius: 2px;
  box-shadow: 2px 2px 5px 2px rgba(0, 0, 0, 0.5);
  z-index: 2;
}
.behind-one{
  position: relative;
  height: 4px;
  width: 98%;
  margin-left: 1%;
  border-radius: 1px;
  background-color: rgb(238, 227, 210);
  box-shadow: 1px 1px 2px 1px rgba(0, 0, 0, 0.5);
  z-index: 1;
}
.behind-two{
  position: relative;
  height: 4px;
  width: 96%;
  margin-left: 2%;
  border-radius: 1px;
  background-color: rgb(238, 227, 210);
  box-shadow: 1px 1px 2px 1px rgba(0, 0, 0, 0.5);
  z-index: 0;
}
</style>
<script>
  import XhzTitle from "./components/XhzTitle.vue";
  import XhzInput from "./components/XhzInput.vue";
  import XhzList from './components/XhzList.vue';
  import XhzFooter from './components/XhzFooter.vue';

  export default{
    components: {
      XhzTitle:XhzTitle,
      XhzInput:XhzInput,
      XhzList:XhzList,
      XhzFooter:XhzFooter
    },
    data (){
      return{
        mylist:[
          
        ],
        url:'/XhzNotepad/Get'
      }
    },
    created(){
        this.fetchData();
      },
    methods:{
      handleAdd(toInput){
        const data = {
          time: new Date().toTimeString(),
          task1: toInput
        }
        this.$http.post('/XhzNotepad/Add',data)
          .then(() => {
            // alert(response.data);
            this.fetchData();
        })
        .catch(error => {
          console.error(error);
        });
      },
      haddleRemove(id){
        this.$http.delete(`/XhzNotepad/Delete?id=${id}`)
        .then(()=>{
          this.fetchData();
        }).catch(error => {
          console.error(error);
        })
      },
      handleClear(){
        this.$http.delete('/XhzNotepad/DeleteAll')
        .then(()=>{
          this.fetchData();
        }).catch(error => {
          console.error(error);
        })
      },
      fetchData(){
        this.$http.get('/XhzNotepad/Get')
        .then(response => {
        this.mylist = response.data;
        })
        .catch(error => {
          console.error(error);
        });
      }
    }
  }
</script>
