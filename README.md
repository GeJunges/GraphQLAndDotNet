# GraphQLAndDotNet
GraphQl and Dotnet 
 
 # Query Get All
 ```
 {
  products {
    id,
    name,
    price
  }
}
 ```
# Query Get By Id
```
query getById($id:Int)
{  
  product(id:$id)
  {
    id,
    name,
    price
  }
}
```
## Query Variable
```
{
  "id": 1
}
```
# Mutation Add
```
mutation createProd($product:ProductInputType){
  createProduct(product: $product){
    id,
    name,
    price
  }
}
```
## Query Variable
```
{
  "product": {
    "name": "test",
    "price": 3.5
  }
}
```
# Mutation Update
```
mutation editProd($id:Int, $product:ProductInputType){
  updateProduct(id:$id, product:$product){
    name,
    price
  }
}

```
## Query Variable
```
{
  "id": 4,
  "product": {
    "name": "candy",
    "price": 1.99
  }
}
```
# Mutation Delete
```
mutation deletePrd($id:Int){
  deleteProduct(id:$id)
}
```
## Query Variable
```
{
  "id": 6
}
```