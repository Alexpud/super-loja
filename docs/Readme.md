# Histórias

## Como administrador gostaria de poder cadastrar produtos

Como um administrador da plataforma, gostaria de poder cadastrar os produtos com as seguintes informações:

- Nome
- Codigo
- Marca
- Peso Unitário
- Quantidade
- Valor

## Como adminsitrador gostaria de poder cadastrar promoções para produtos

Como um administrador da plataforma, gostaria de poder cadastrar promoções para produtos, com os valores do desconto sendo em porcentagem, maiores que zero e
menores que 100. Ao criar uma promoção, ela deve vir desativada

## Não será possivel alterar o valor da promoção já cadastrada

Não será possível alterar o valor de uma promoção. O correto será descontinuar ela e cadastrar/ativar outra.

## Uma promoção terá um tempo de expiração

Uma promoção terá um tempo de expiração onde após essa data, elas serão automaticamente desativadas.

## Uma promoção não pode ser cadastrada com o valor zerado

Uma promoção não poderá ser cadastrada com valor zerado ou negativado. 

## Os clientes devem poder se registrar na plataforam

Os clientes ao acessarem a plataforma, devem ser capazes de se registrar dado que as informações passadas sejam validas. As informações dos clientes são:

- Nome
- Endereços
    - Rua
    - Complemento
    - Numero
    - CEP

Um cliente pode ter mais de um endereço e ao finalizar uma compra ele pode selecionar para qual endereço enviar a compra.

## Um cliente deve ser capaz de realizar uma compra

O cliente deve ser capaz de realizar uma compra com 1 ou mais produtos, e nesse processo, escolher também o método de entrega, aplicar vouchers de desconto,
endereço de entrega. Os vouchers são aplicados ao valor resultante da venda.

Diferentes métodos de entrega, terão valores diferentes.

## O administrador deverá ser capaz de ter uma visão geral das compras realizadas pelos clientes

O administrador deve ser capaz de visualizar as compras realizadas, sendo capaz de ver os valores dos items no momento da compra em especifico.

## O adminsitrador é capaz de alterar os valores dos produtos

O administrador deve ser capaz de alterar o valor dos produtos

## Ao finalizar uma compra, os produtos do estoque que foram comprados levarão baixa de acordo com os items comprados.

Ao finalizar uma compra os niveis de estoque dos produtos compradso devem ser atualizados e caso estejam abaixo do nivel minimo, um alerta deve ser enviado
ao email do gestor para poder pedir mais items.

## O cliente poderá solicitar o cancelamento da compra

O cliente deve ser capaz de realizar o cancelamento de uma compra e ter o valor da compra extornado. Ao cancelar a compra, os produtos serão retornados a empresa
e os níveis do estoque dos mesmos deverão ser atualizados também.