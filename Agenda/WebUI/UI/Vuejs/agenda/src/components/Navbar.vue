<script>
export default {
    name: "Navbar"
}
</script>

<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
    <div class="container-fluid">
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
            <router-link to="/contatos" class="nav-link active" aria-current="page">Contatos</router-link>
            </li>
            <li class="nav-item">
            <router-link to="/compromisso" class="nav-link active" aria-current="page">Compromissos</router-link>
            </li>
            <li class="nav-item">
            <router-link to="/backup" class="nav-link active" aria-current="page">Backup</router-link>
            </li>
        </ul>
        </div>
    </div>
    </nav>
</template>