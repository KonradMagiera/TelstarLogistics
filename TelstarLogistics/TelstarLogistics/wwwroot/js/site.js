// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



const modal = docuement.querySelector("#modal")
const openModal = docuement.querySelector(".open-button")
const closeModal = docuement.querySelector(".close-button")

openModal.addEventListener('click', () => {
    modal.showModal()
})

closeModal.addEventListener('click', () => {
    modal.showModal()
})


