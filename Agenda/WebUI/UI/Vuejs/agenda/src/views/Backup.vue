<script setup>
    import axios from 'axios'
    import alerta from '../utils.js'

    function backup(){
        axios.get('https://localhost:7165/api/v1/contato/backup/download', { responseType: 'blob' })
                .then(response => {
                    if(response){
                        forceFileDownload(response, 'backup_agenda')
                        alerta('O backup foi efetuado com sucesso. O download terminou.', 'success')
                    }
                })
                .catch(error => {
                    alerta('Ocorreu um erro. Não foi possível fazer o backup', 'warning')
                })
    }

    function forceFileDownload(response, title) {
      const url = window.URL.createObjectURL(new Blob([response.data]))
      const link = document.createElement('a')
      link.href = url
      link.setAttribute('download', title)
      document.body.appendChild(link)
      link.click()
    }
</script>

<template>
    <p><label class="form-label">Clique para fazer backup da agenda e baixar o arquivo</label></p>
    <button @click="backup" type="submit" class="btn btn-primary">Fazer Backup</button>
</template>