// Defini��o da fun��o getHistoricoData
const getHistoricoData = async () => {
    try {
        const response = await fetch('/Agenda/GetHistorico');
        const responseClone = response.clone(); // Clona a resposta para evitar que ela seja consumida
        const data = await responseClone.json(); // L� a resposta clonada

        console.log('Dados do hist�rico:', data);  
        return data;
    } catch (error) {
        console.error('Erro ao obter dados do hist�rico:', error);
        return [];
    }
};

// Exporta��o da fun��o
export { getHistoricoData };