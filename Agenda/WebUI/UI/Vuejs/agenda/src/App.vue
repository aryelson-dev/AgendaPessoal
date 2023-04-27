<script setup>
import Navbar from './components/Navbar.vue'
</script>

<template>
  <div class="container"  style="max-width: 540px;">
    <Navbar></Navbar>
    <router-view></router-view>
  </div>
</template>

<style>
</style>
