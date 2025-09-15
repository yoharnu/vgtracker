<script setup>
  var props = defineProps(['game']);
  const data = props.game;
</script>

<template>
  <div class="card">
    <div class="card-body container">
      <div class="row">
        <div class="col-1">
          <img v-if="data.cover.url" :src="data.cover.url" class="searchCover" />
        </div>
        <div class="col">
          <h5 class="card-title">{{ data.name }}<span v-if="data.year > 0"> ({{data.year}})</span></h5>
          <small class="card-text" v-if="data.parentName"> {{data.parentName}}<span v-if="data.parentYear > 0"> ({{data.parentYear}})</span> {{data.gameType}}</small>
        </div>
      </div>
    </div>
  </div>
</template>


<style>
  .searchCover {
    max-width: 90px;
  }
</style>
