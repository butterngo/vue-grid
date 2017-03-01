Vue.component('v-grid',function (resolve, reject) {
  resolve({
    template: '#grid-template',
      props: {
        data: Array,
        columns: Array,
        filterKey: String
      }
  })
})

