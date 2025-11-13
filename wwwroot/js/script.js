const overlay = document.getElementById('overlay');
const modal = document.getElementById('modal');
const openModalBtn = document.getElementById('openModalBtn');
const closeBtn = document.getElementById('closeBtn');

// Abrir modal con animación fluida
openModalBtn.addEventListener('click', () => {
  overlay.classList.add('active'); // Aparece el fondo
  // Pequeño delay para permitir que el overlay se monte antes de animar el modal
  setTimeout(() => {
    modal.classList.add('active'); // Desliza el modal
  }, 10);
});

// Función para cerrar el modal
function closeModal() {
  modal.classList.remove('active'); // Desliza hacia afuera
  // Espera que termine la animación antes de ocultar el fondo
  setTimeout(() => overlay.classList.remove('active'), 300);
}

// Cerrar con botón o clic fuera
closeBtn.addEventListener('click', closeModal);
overlay.addEventListener('click', (e) => {
  if (e.target === overlay) closeModal();
});
