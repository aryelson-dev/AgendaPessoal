<script setup>
import { ref, computed } from 'vue'
import axios from 'axios'

let cep = ref('')

let contatoform = ref({
    nome: "",
    telefone1: "",
    telefone2: "",
    email: "",
    dataNascimento: "",
    endereco: {
        cep: "",
        rua: "",
        numero: "",
        complemento: "",
        bairro: "",
        cidade: "",
        estado: ""
    }
})

let enderecoPreenchido = computed(() => {

    //let cep = contatoform.value.endereco.cep
    let _cep = cep.value
    if(cep && _cep.length > 7 && _cep.length < 11){
        axios.get('https://localhost:7165/api/v1/correios/cep/' + _cep)
            .then(result => {
                if(result.data) {
                    contatoform.value.endereco = result.data
                }
            
            console.log(result.data)
        })
   }
})

</script>

<template>
    <div class="fs-1 text">
        Novo Contato
        {{ enderecoPreenchido }}
    </div>
    <form>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Nome</label>
            <input v-model="contatoform.nome" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="row" style="margin-bottom: 15px;">
            <div class="col">
                <label for="exampleInputEmail1" class="form-label">Telefone 1</label>
                <input v-model="contatoform.telefone1" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
            <div class="col">
                <label for="exampleInputEmail1" class="form-label">Telefone 2</label>
                <input v-model="contatoform.telefone2" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Email</label>
            <input v-model="contatoform.email" type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Data de Nascimento</label>
            <input v-model="contatoform.dataNascimento" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Cep</label>
            <input v-model="cep" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Rua</label>
            <input v-model="contatoform.endereco.rua" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Número</label>
            <input v-model="contatoform.endereco.numero" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Complemento</label>
            <input v-model="contatoform.endereco.complemento" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="row">
            <div class="col">
                <label for="exampleInputEmail1" class="form-label">Bairro</label>
                <input v-model="contatoform.endereco.bairro" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
            <div class="col">
                <label for="exampleInputEmail1" class="form-label">Cidade</label>
                <input v-model="contatoform.endereco.cidade" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
            <div class="col">
                <label for="exampleInputEmail1" class="form-label">Estado</label>
                <input v-model="contatoform.endereco.estado" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
        </div>
        <br>

        <button type="submit" class="btn btn-primary">Cadastrar</button>
    </form>

</template>