<script setup>
  import { ref, onMounted } from 'vue'
  import axios from 'axios'

  let contatos = []

  onMounted(() => {
    axios.get('https://localhost:7165/api/v1/contato/lista')
      .then(result => {
        console.log(result.data)
        contatos = result.data 
      })
  })
</script>

<template>
  <h3>Contatos</h3>
  <br>
  <div>
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Nome</th>
          <th scope="col">Telefone 1</th>
          <th scope="col">Telefone 2</th>
          <th scope="col">E-mail</th>
          <th scope="col">Nascimento</th>
          <th scope="col">Endereço</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="contato in contatos" :key="id">
          <td>{{ contato.nome }}</td>
          <td>{{ contato.telefone1 }}</td>
          <td>{{ contato.telefone2 }}</td>
          <td>{{ contato.email }}</td>
          <td>{{ contato.dataNascimento }}</td>
          <td>{{ contato.Endereco }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style>
</style>