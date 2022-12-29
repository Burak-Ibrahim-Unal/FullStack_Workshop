import * as yup from "yup";

export const validationSchema = yup.object({
    name: yup.string().required(),
    brand: yup.string().required(),
    type: yup.string().required(),
    price: yup.number().required().moreThan(1),
    stockQuantity: yup.number().required().min(0),
    description: yup.string().required(),
    file: yup.mixed().when("pictureUrl", {
        is: (value: string) => !value,
        then: yup.mixed().required("Please upload photo...")
    }),

})