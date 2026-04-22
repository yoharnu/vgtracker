<script setup>
  import { ref } from 'vue'
  import GameSearchResult from './GameSearchResult.vue'

  const searchbox = ref('')
  const dataArray = ref([])

  const searchGame = debounce(async function () {
    if (searchbox.value.length < 2) {
      return
    }

    console.log('Searching for:', searchbox.value)

    const response = await fetch(`/api/IGDB/games/search/${encodeURIComponent(searchbox.value)}`)

    dataArray.value = []

    if (response.ok) {
      dataArray.value = await response.json()
      console.log(dataArray.value)
    }
  }, 500)

  function debounce(fn, wait) {
    let timer;
    return function (...args) {
      if (timer) {
        clearTimeout(timer);
      }
      const context = this;
      timer = setTimeout(() => {
        fn.apply(context, args);
      }, wait);
    };
  }
</script>

<template>
  <input type="text" v-model="searchbox" @input="searchGame" />
  <br />
  <div>
    <GameSearchResult v-for="data in dataArray" :key="data.id" :game="data" />
  </div>
</template>
