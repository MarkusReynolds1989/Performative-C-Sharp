use std::str;
use std::{mem, slice};

#[no_mangle]
pub unsafe extern "C" fn reverse_array(input: *const i32, count: usize) -> *const i32 {
    let items = slice::from_raw_parts(input, count);
    let vector = items
        .iter()
        .rev()
        .map(|i| -> i32 { *i })
        .collect::<Vec<i32>>();

    // Use this when I want to transfer the ownership to outside of rust.
    // Now the caller will have to handle the memory.
    let result = vector.as_ptr();
    mem::forget(vector);

    result
}

#[no_mangle]
pub unsafe extern "C" fn c_sharp_map(input: *const i32, mapper: extern fn (i32) -> i32, count: usize) -> *const i32 {
    let items = slice::from_raw_parts(input, count);
    let vector = items
        .iter()
        .map(|i| -> i32 { mapper(*i) })
        .collect::<Vec<i32>>();

    let result = vector.as_ptr();
    mem::forget(vector);

    result
}


#[repr(C)]
pub struct Person {
    pub name: *const u8,
    pub age: i32,
}

impl Person {
    #[no_mangle]
    pub unsafe extern "C" fn create_person(
        name_bytes: *const u8,
        count: usize,
        age: i32,
    ) -> Person {
        let name = str::from_utf8(slice::from_raw_parts(name_bytes, count))
            .unwrap()
            .to_uppercase();

        println!("{}", name);

        let name_pointer = name.as_bytes().as_ptr();
        mem::forget(name);

        Person {
            name: name_pointer,
            age: age + 1,
        }
    }

    #[no_mangle]
    pub unsafe extern "C" fn increment_age(person: Person) -> Person {
        Person {
            age: person.age + 1,
            ..person
        }
    }
}
