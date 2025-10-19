// ⚡ Inicializa Mercado Pago con tu PUBLIC_KEY de producción
const mp = new MercadoPago("TU_PUBLIC_KEY_PRODUCCION", {
  locale: "es-AR"
});

// Escucha clic del botón
document.getElementById("mpCheckoutBtn").addEventListener("click", async () => {
  try {
    // Llamar al backend para crear la preferencia
    const response = await fetch("/MercadoPago/CreatePreference");
    if (!response.ok) throw new Error("Error al crear preferencia");

    const data = await response.json();
    const preferenceId = data.preferenceId;

    // Abrir checkout
    mp.checkout({
      preference: { id: preferenceId },
      autoOpen: true
    });
  } catch (err) {
    alert("⚠️ Error al conectarse con Mercado Pago.");
    console.error(err);
  }
});
