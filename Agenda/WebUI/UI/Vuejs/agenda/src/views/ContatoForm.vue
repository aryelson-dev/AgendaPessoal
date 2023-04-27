<script setup>
import { ref, computed, toRaw } from 'vue'
import axios from 'axios'
import { useRouter } from 'vue-router'

let cep = ref('')

let contatoform = ref({
    nome: "",
    telefone1: "",
    telefone2: "",
    email: "",
    dataNascimento: ""
})

let endereco = ref({
    cep: "",
    rua: "",
    numero: "",
    complemento: "",
    bairro: "",
    cidade: "",
    estado: ""
})

const router = useRouter()

let enderecoPreenchido = computed(() => {

    let _cep = cep.value
    if(cep && _cep.length > 7 && _cep.length < 11){
        axios.get('https://localhost:7165/api/v1/correios/cep/' + _cep)
            .then(result => {
                if(result.data) {
                    contatoform.value.endereco = result.data
                }
            })
            .catch(function (error) {
                console.log(error);
            });
   }
   else {
    contatoform.value.endereco = {}
   }
})

function salva(){
    let _contato = toRaw(contatoform.value)
    let _endereco = toRaw(endereco.value)
    _contato.endereco = null;

    if(_endereco && _endereco.cep){
        _contato.endereco = _endereco
    }

    axios.post('https://localhost:7165/api/v1/contato/adiciona/', _contato)
            .then(result => {
                contatoform = {}
                alerta()
                scrollToTop()
            })
            .catch(error => {
                console.log(error)
            })
}

function cancela(){
    contatoform = {}
    router.push('/contato')
}

function alerta(){
    const alertPlaceholder = document.getElementById('liveAlertPlaceholder')
    
    console.log('no alerta')

    const appendAlert = (message, type) => {
        const wrapper = document.createElement('div')
        wrapper.innerHTML = [
            `<div class="alert alert-${type} alert-dismissible" role="alert">`,
            `   <div>${message}</div>`,
            '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
            '</div>'
        ].join('')

        alertPlaceholder.append(wrapper)
    }

    appendAlert('Cadastro efetuado com sucesso!', 'success')
}

    function scrollToTop() {
        window.scrollTo(0,0);
    }

</script>

<template>

    <div id="liveAlertPlaceholder"></div>

    <div class="fs-1 text">
        Novo Contato
        {{ enderecoPreenchido }}
    </div>

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
            <input v-model="endereco.rua" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Número</label>
            <input v-model="endereco.numero" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Complemento</label>
            <input v-model="endereco.complemento" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="row">
            <div class="col">
                <label for="exampleInputEmail1" class="form-label">Bairro</label>
                <input v-model="endereco.bairro" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
            <div class="col">
                <label for="exampleInputEmail1" class="form-label">Cidade</label>
                <input v-model="endereco.cidade" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
            <div class="col">
                <label for="exampleInputEmail1" class="form-label">Estado</label>
                <input v-model="endereco.estado" type="input" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
        </div>
        <br>

        <button @click="salva" type="submit" class="btn btn-primary">Cadastrar</button>
        <button @click="cancela" type="submit" class="btn btn-secondary" style="margin-left: 5px;">Cancelar</button>

</template>