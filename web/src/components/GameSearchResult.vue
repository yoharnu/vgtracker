<script setup>
  var props = defineProps(['game']);
  const data = props.game;
</script>

<template>
  <p>
    {{ data.name }}<span v-if="data.year > 0"> ({{data.year}})</span><div v-if="data.parentName"> {{data.parentName}}<span v-if="data.parentYear > 0"> ({{data.parentYear}})</span> {{data.gameType}}</div>
  </p>
</template>
