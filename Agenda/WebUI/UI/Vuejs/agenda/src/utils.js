function alerta(mensagem, tipo){
    const alertPlaceholder = document.getElementById('liveAlertPlaceholder')

    const alertAnterior = document.getElementById('div_alerta')
    if(alertAnterior){
        alertAnterior.remove();
    }

    const appendAlert = (message, type) => {
        const wrapper = document.createElement('div')
        wrapper.setAttribute("id", "div_alerta");

        wrapper.innerHTML = [
            `<div class="alert alert-${type} alert-dismissible" role="alert">`,
            `   <div>${message}</div>`,
            '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
            '</div>'
        ].join('')

        alertPlaceholder.append(wrapper)
    }

    appendAlert(mensagem, tipo)
    scrollToTop()
}

function scrollToTop() {
    window.scrollTo(0,0);
}

export default alerta