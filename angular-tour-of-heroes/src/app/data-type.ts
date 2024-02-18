export interface SignUp{
name:string,
password:string,
email:string
}

export interface login{
    password:string,
    email:string 
}
export interface Product {
    id: number;
    name: string;
    description: string;
    image: string;
    categoryId: number;
    categoryName: string;
  }