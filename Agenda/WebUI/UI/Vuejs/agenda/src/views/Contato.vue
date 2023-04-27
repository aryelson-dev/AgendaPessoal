<script setup>
  import { ref, onMounted, computed } from 'vue'
  import axios from 'axios'

  let contatos = ref([])
  let filtroContatos = ref('')

    onMounted(() => {
        axios.get('https://localhost:7165/api/v1/contato/lista')
            .then(result => {
            contatos.value = result.data
            //console.log(result.data)
        })
    })

    let listaFiltrada = computed(() => {
        return contatos.value.filter(item => {
            return item.nome.toLowerCase().indexOf(filtroContatos.value.toLowerCase()) > -1
        })
    })

</script>

<template>
    <div class="fs-1 text">Contatos</div>
    <form v-if="contatos && contatos.length > 0" class="d-flex" role="search">
            <input v-model="filtroContatos" class="form-control me-2" type="search" placeholder="Filtrar contatos" aria-label="filtrar">
        </form>
    <div v-if="contatos && contatos.length > 0" class="card mt-3" v-for="contato in listaFiltrada" :key="contato.id">
        <h5 class="card-header">{{ contato.nome }}</h5>
        <div class="card-body">
            <span>
            <span class="font-weight-bold">Telefones: </span> {{ contato.telefone1 }} 
            <span v-if="contato.telefone2"> / {{ contato.telefone2 }} </span><br>
            </span>
            
            <span>
            <span class="font-weight-bold">E-mail: </span>{{ contato.email }}<br>
            </span>

            <span v-if="contato.dataNascimento">
            <span class="font-weight-bold">Data de nascimento: </span>{{ contato.dataNascimento }}<br>
            </span>

            <span v-if="contato.endereco">
            <br>
            <h6 class="font-weight-bold">Endereço:</h6>
            <span class="card-text"><span class="font-weight-bold">Cep:</span> {{ contato.endereco.cep  }} </span>
            <br>
            <span class="card-text"><span class="font-weight-bold">Rua:</span> {{ contato.endereco.rua  }} <span v-if="contato.endereco.numero">, {{ contato.endereco.numero  }}</span> </span>
            <br>
            <span class="card-text"><span class="font-weight-bold">Complemento:</span> {{ contato.endereco.complemento  }} </span>
            <br>
            <span class="card-text"><span class="font-weight-bold">Bairro:</span> {{ contato.endereco.bairro  }} </span>
            <br>
            <span class="card-text"><span class="font-weight-bold">Cidade:</span> {{ contato.endereco.cidade  }}-{{ contato.endereco.estado }} </span>
            <br>
            </span>

            <br>

            <a href="#" class="card-link">Editar</a>
            <a href="#" class="card-link">Excluir</a>
        </div>
        </div>

        <div v-else>
        <h6>Nenhum contato cadastrado</h6>
    </div>
</template>