// Definição da função getHistoricoData
const getHistoricoData = async () => {
    try {
        const response = await fetch('/Agenda/GetHistorico');
        const responseClone = response.clone(); // Clona a resposta para evitar que ela seja consumida
        const data = await responseClone.json(); // Lê a resposta clonada

        console.log('Dados do histórico:', data);  
        return data;
    } catch (error) {
        console.error('Erro ao obter dados do histórico:', error);
        return [];
    }
};

// Exportação da função
export { getHistoricoData };