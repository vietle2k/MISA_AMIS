<template>
  <div class="app">
    <TheNavbar /> 
    <TheHeader />
    <TheContent />
  </div>
</template>

<script>
import TheNavbar from "./components/layout/TheNavbar.vue";
import TheHeader from "./components/layout/TheHeader.vue";
import TheContent from "./components/layout/TheContent";
export default {
  name: 'App',
  components: {
    TheNavbar,
    TheHeader,
    TheContent
  }
}
</script>

<style>
@import './style/main.css';

body {
  background: #f4f5f8;
  color: #111;
  margin: 0;
}

body .app {
  height: 100%;
  display: flex;
  margin: 0;
}

</style>
