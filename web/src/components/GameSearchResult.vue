<script setup>
  var props = defineProps(['game']);
  const game = props.game;
</script>

<template>
  <div class="card">
    <div class="card-body container">
      <div class="row">
        <div class="col-1">
          <img v-if="game.coverURL" :src="game.coverURL" class="searchCover" />
        </div>
        <div class="col">
          <h5 class="card-title">{{ game.name }}<span v-if="game.year > 0"> ({{game.year}})</span></h5>
          <small class="card-text" v-if="game.parentName"> {{game.parentName}}<span v-if="game.parentYear > 0"> ({{game.parentYear}})</span> {{game.gameType}}</small>
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
