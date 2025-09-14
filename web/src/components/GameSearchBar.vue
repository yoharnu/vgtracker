<script setup>
  import { ref } from 'vue'

  const searchbox = ref('')
  const dataArray = ref([])

  async function searchGame() {
    if (searchbox.value.length < 2) {
      return
    }

    const response = await fetch(`/api/IGDB/games/search/${encodeURIComponent(searchbox.value)}`)
    if (response.ok) {
      dataArray.value = await response.json()
    }

    console.log('Searching for:', searchbox.value)
  }
</script>

<template>
  <input type="text" v-model="searchbox" @input="searchGame" />
  <br/>
  <ul>
    <li v-for="data in dataArray">{{ data.name }}<span v-if="data.year > 0"> ({{data.year}})</span></li>
  </ul>
</template>
