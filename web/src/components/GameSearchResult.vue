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
          <h5 class="card-title">
            {{ game.name }}<span v-if="game.year > 0"> ({{game.year}})</span>
            <span v-if="game.gameType && game.parentName" class="badge bg-primary tag">{{game.gameType}}</span>
            <span v-for="platform in game.platforms" :key="platform" class="badge bg-secondary tag">{{platform}}</span>
          </h5>
          <p class="card-text" v-if="game.summary">{{ game.summary }}</p>
        </div>
      </div>
    </div>
  </div>
</template>


<style>
  .searchCover {
    max-width: 90px;
  }

  .tag {
    margin-left: 5px;
  }
</style>
