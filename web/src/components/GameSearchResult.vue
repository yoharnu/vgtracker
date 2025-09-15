<script setup>
  var props = defineProps(['game']);
  const data = props.game;
</script>

<template>
  <div class="card">
    <div class="card-body">
      <div class="card-title">{{ data.name }}<span v-if="data.year > 0"> ({{data.year}})</span></div>
      <div class="card-text" v-if="data.parentName"> {{data.parentName}}<span v-if="data.parentYear > 0"> ({{data.parentYear}})</span> {{data.gameType}}</div>
    </div>
  </div>
</template>
